using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

/// <summary>
/// Validator for GerProductCommand
/// </summary>
public class GetProductValidator : AbstractValidator<GetProductCommand>
{
    /// <summary>
    /// Initializes validation rules for GerProductCommand
    /// </summary>
    public GetProductValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
    }
}
