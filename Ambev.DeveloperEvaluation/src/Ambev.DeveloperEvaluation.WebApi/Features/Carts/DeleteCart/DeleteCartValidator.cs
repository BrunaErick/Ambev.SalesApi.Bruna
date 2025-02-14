using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.DeleteCart;

/// <summary>
/// Validator for DeleteUserRequest
/// </summary>
public class DeleteCartValidator : AbstractValidator<DeleteCartRequest>
{
    /// <summary>
    /// Initializes validation rules for DeleteUserRequest
    /// </summary>
    public DeleteCartValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
    }
}
