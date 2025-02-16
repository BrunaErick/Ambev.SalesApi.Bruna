using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;

/// <summary>
/// API response model for Getcart operation
/// </summary>
public class GetCartResponse
{
    /// <summary>
    /// Gets the unique identifier of the cart
    public int Id { get; set; }

    /// <summary>
    /// Gets the cart's userId
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Gets the Date
    /// </summary>
    public DateTime Date { get; set; }

}
