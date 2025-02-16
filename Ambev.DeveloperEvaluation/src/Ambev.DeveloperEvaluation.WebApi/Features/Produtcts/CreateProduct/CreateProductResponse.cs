using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// API response model for Createproduct operation
/// </summary>
public class CreateProductResponse
{

    /// <summary>
    /// Gets the product's Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets the product's Title
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product's Price
    /// </summary>
    public Decimal Price { get; set; }

    /// <summary>
    /// Gets the product's Description
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

}
