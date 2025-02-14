using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;

/// <summary>
/// Validator for GetUserRequest
/// </summary>
public class GetCartRequestValidator : AbstractValidator<GetCartRequest>
{
    /// <summary>
    /// Initializes validation rules for GetUserRequest
    /// </summary>
    public GetCartRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
    }
}
