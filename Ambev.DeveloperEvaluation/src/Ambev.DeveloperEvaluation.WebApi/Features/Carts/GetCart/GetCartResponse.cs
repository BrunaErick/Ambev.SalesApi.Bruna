using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;

/// <summary>
/// API response model for Getcart operation
/// </summary>
public class GetCartResponse
{
    /// <summary>
    /// The unique identifier of the cart
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The cart's full name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The cart's email address
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The cart's phone number
    /// </summary>
    public string Phone { get; set; } = string.Empty;

}
