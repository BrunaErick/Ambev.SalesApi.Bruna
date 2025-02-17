using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

/// <summary>
/// Represents a request to create a new cart in the system.
/// </summary>
public class CreateCartRequest
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