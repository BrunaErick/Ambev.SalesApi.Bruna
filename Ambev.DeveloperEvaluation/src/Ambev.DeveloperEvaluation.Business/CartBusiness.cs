using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Business
{
    /// <summary>
    /// Implementation of ICartBusiness using Entity Framework Core
    /// </summary>
    public class CartBusiness : ICartBusiness
    {
        private readonly ICartRepository _repo;

        /// <summary>
        /// Initializes a new instance of CartBusiness
        /// </summary>
        /// <param name="context">The database context</param>
        public CartBusiness(ICartRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Creates a new Cart in the database
        /// </summary>
        /// <param name="Cart">The Cart to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created Cart</returns>
        public async Task<Guid> CreateAsync(Cart Cart, CancellationToken cancellationToken = default)
        {
           return  await _repo.CreateAsync(Cart, cancellationToken);
        }

        /// <summary>
        /// Retrieves a Cart by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the Cart</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Cart if found, null otherwise</returns>
        public async Task<Cart?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _repo.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Deletes a Cart from the database
        /// </summary>
        /// <param name="id">The unique identifier of the Cart to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the Cart was deleted, false if not found</returns>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _repo.DeleteAsync(id, cancellationToken);
        }
    }
}
