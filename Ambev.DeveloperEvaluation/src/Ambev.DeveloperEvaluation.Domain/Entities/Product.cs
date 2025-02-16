using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


/// <summary>
/// Represents a product in the system
/// </summary>
public class Product : BaseEntity, IProduct
{

    /// <summary>
    /// Gets the product's full Id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets the product's full Title.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product's Price
    /// </summary>
    public Decimal Price { get; set; }

    /// <summary>
    /// Gets the product's Description
    /// </summary>
    public string Description { get; set; } = string.Empty ;

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
    public Decimal RatingRate { get;     set; }

    /// <summary>
    /// Gets the product's RatingCount
    /// </summary>
    public int RatingCount { get; set; }

    
}