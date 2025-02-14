namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.DeleteCart;

/// <summary>
/// Request model for deleting a user
/// </summary>
public class DeleteCartRequest
{
    /// <summary>
    /// The unique identifier of the user to delete
    /// </summary>
    public Guid Id { get; set; }
}
