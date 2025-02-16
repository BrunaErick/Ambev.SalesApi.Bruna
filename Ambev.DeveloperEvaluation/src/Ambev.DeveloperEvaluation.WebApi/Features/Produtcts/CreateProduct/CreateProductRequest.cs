using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Represents a request to create a new product in the system.
/// </summary>
public class CreateProductRequest
{
    /// <summary>
    /// Gets the product's full Title.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product's Price address.
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
    /// Gets the product's RatingCountRatingCount
    /// </summary>
    public int RatingCount { get; set; }

}