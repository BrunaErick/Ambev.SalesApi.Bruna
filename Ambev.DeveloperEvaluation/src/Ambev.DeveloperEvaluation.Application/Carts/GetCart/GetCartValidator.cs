using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

/// <summary>
/// Validator for GetUserCommand
/// </summary>
public class GetCartValidator : AbstractValidator<GetCartCommand>
{
    /// <summary>
    /// Initializes validation rules for GetUserCommand
    /// </summary>
    public GetCartValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
    }
}
