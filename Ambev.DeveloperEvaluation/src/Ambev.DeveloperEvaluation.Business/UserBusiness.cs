using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Business
{
    /// <summary>
    /// Implementation of IUserBusiness using Entity Framework Core
    /// </summary>
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _repo;

        /// <summary>
        /// Initializes a new instance of UserBusiness
        /// </summary>
        /// <param name="context">The database context</param>
        public UserBusiness(IUserRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Creates a new user in the database
        /// </summary>
        /// <param name="user">The user to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created user</returns>
        public async Task<Guid> CreateAsync(User user, CancellationToken cancellationToken = default)
        {
           return  await _repo.CreateAsync(user, cancellationToken);
        }

        /// <summary>
        /// Retrieves a user by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the user</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The user if found, null otherwise</returns>
        public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _repo.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Retrieves a user by their email address
        /// </summary>
        /// <param name="email">The email address to search for</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The user if found, null otherwise</returns>
        public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _repo.GetByEmailAsync(email, cancellationToken);
        }

        /// <summary>
        /// Deletes a user from the database
        /// </summary>
        /// <param name="id">The unique identifier of the user to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the user was deleted, false if not found</returns>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _repo.DeleteAsync(id, cancellationToken);
        }
    }
}
