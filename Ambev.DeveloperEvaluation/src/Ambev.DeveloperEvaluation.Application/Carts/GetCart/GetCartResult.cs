using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

/// <summary>
/// Response model for GetCart operation
/// </summary>
public class GetCartResult
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
