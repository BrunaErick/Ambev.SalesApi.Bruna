using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;

/// <summary>
/// Handler for processing DeleteUserCommand requests
/// </summary>
public class DeleteCartHandler : IRequestHandler<DeleteCartCommand, DeleteCartResponse>
{
    private readonly ICartRepository _cartRepository;

    /// <summary>
    /// Initializes a new instance of DeleteUserHandler
    /// </summary>
    /// <param name="userRepository">The user repository</param>
    /// <param name="validator">The validator for DeleteUserCommand</param>
    public DeleteCartHandler(
        ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    /// <summary>
    /// Handles the DeleteUserCommand request
    /// </summary>
    /// <param name="request">The DeleteUser command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<DeleteCartResponse> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteCartValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _cartRepository.DeleteAsync(request.Id, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"User with ID {request.Id} not found");

        return new DeleteCartResponse { Success = true };
    }
}
