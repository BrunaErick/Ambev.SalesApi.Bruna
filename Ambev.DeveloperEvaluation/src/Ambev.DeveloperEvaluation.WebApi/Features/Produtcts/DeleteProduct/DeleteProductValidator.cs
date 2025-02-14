using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct;

/// <summary>
/// Validator for DeleteProductRequest
/// </summary>
public class DeleteProductValidator : AbstractValidator<DeleteProductRequest>
{
    /// <summary>
    /// Initializes validation rules for DeleteProductRequest
    /// </summary>
    public DeleteProductValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
    }
}
