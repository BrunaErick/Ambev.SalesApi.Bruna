using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Command for creating a new product.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a product, 
/// including productname, password, phone number, email, status, and role. 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="CreateproductResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="CreateproductCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class CreateProductCommand : IRequest<CreateProductResult>
{

    /// <summary>
    /// Gets the product's ID.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets the product's full Title.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product's Price.
    /// </summary>
    public Decimal Price { get; set; }

    /// <summary>
    /// Gets the product's Description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets the Category
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Gets the Image
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product's RatingRate
    /// </summary>
    public Decimal RatingRate { get; set; }

    /// <summary>
    /// Gets the product's RatingCount
    /// </summary>
    public int RatingCount { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new CreateProductCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}