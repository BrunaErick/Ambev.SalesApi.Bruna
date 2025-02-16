using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

/// <summary>
/// Response model for GetCart operation
/// </summary>
public class GetCartResult
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
