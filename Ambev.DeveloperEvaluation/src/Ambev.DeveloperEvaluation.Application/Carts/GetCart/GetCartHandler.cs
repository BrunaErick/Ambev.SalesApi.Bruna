using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

/// <summary>
/// Handler for processing GetUserCommand requests
/// </summary>
public class GetCartHandler : IRequestHandler<GetCartCommand, GetCartResult>
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetUserHandler
    /// </summary>
    /// <param name="userRepository">The user repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetUserCommand</param>
    public GetCartHandler(
        ICartRepository cartRepository,
        IMapper mapper)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetUserCommand request
    /// </summary>
    /// <param name="request">The GetUser command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user details if found</returns>
    public async Task<GetCartResult> Handle(GetCartCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetCartValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var user = await _cartRepository.GetByIdAsync(request.Id, cancellationToken);
        if (user == null)
            throw new KeyNotFoundException($"User with ID {request.Id} not found");

        return _mapper.Map<GetCartResult>(user);
    }
}
