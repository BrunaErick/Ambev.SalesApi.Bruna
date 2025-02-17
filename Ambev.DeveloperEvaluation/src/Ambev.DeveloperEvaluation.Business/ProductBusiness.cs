using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Business
{
    /// <summary>
    /// Implementation of IProductBusiness using Entity Framework Core
    /// </summary>
    public class ProductBusiness : IProductBusiness
    {
        private readonly IProductRepository _repo;

        /// <summary>
        /// Initializes a new instance of ProductBusiness
        /// </summary>
        /// <param name="context">The database context</param>
        public ProductBusiness(IProductRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Creates a new Product in the database
        /// </summary>
        /// <param name="Product">The Product to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created Product</returns>
        public async Task<int> CreateAsync(Product Product, CancellationToken cancellationToken = default)
        {
           return  await _repo.CreateAsync(Product, cancellationToken);
        }

        /// <summary>
        /// Retrieves a Product by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the Product</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Product if found, null otherwise</returns>
        public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _repo.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Retrieves all Products
        /// </summary>
        /// <returns>The Product if found, null otherwise</returns>
        public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _repo.GetAllAsync(cancellationToken);
        }

        /// <summary>
        /// Deletes a Product from the database
        /// </summary>
        /// <param name="id">The unique identifier of the Product to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the Product was deleted, false if not found</returns>
        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _repo.DeleteAsync(id, cancellationToken);
        }
    }
}
