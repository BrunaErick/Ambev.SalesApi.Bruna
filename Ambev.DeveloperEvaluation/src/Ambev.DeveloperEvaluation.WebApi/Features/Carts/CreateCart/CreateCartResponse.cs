using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

/// <summary>
/// API response model for Createcart operation
/// </summary>
public class CreateCartResponse
{
    /// <summary>
    /// The unique identifier of the created cart
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The cart's full name
    /// </summary>
    public string cartname { get; set; } = string.Empty;

    /// <summary>
    /// The cart's email address
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The cart's phone number
    /// </summary>
    public string Phone { get; set; } = string.Empty;

}
