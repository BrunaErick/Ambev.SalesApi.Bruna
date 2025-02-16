using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for Cart entity operations
/// </summary>
public interface ICartRepository
{
    /// <summary>
    /// Creates a new Cart in the repository
    /// </summary>
    /// <param name="Cart">The Cart to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created Cart</returns>
    Task<Guid> CreateAsync(Cart cart, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a Cart by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the Cart</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Cart if found, null otherwise</returns>
    Task<Cart?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a Cart from the repository
    /// </summary>
    /// <param name="id">The unique identifier of the Cart to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the Cart was deleted, false if not found</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
