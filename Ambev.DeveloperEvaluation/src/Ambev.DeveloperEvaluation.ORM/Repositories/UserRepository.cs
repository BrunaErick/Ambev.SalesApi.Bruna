using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Azure.Core;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IUserRepository using Entity Framework Core
/// </summary>
public class UserRepository : IUserRepository
{
    private readonly DefaultContext _context;
    private readonly IConfiguration _appSettings;

    /// <summary>
    /// Initializes a new instance of UserRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public UserRepository(DefaultContext context, IConfiguration appSettings)
    {
        _context = context;
        _appSettings = appSettings;
    }

    /// <summary>
    /// Creates a new user in the database
    /// </summary>
    /// <param name="user">The user to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created user</returns>
    public async Task<Guid> CreateAsync(User user, CancellationToken cancellationToken = default)
    {
        var connectionstring = _appSettings.GetConnectionString("DefaultConnection");
        var id = new Guid();
        try
        {
            var sqlQuery = @" Insert into  [AmbevDb].[dbo].[Users] 
            (
                [Username] 
                ,[Password] 
                ,[Phone] 
                ,[Email] 
                ,[Status]  
                ,[Role]
            ) 
            OUTPUT INSERTED.Id
             values(
                @Username
                ,@Password
                ,@Phone
                ,@Email
                ,@Status
                ,@Role)";

                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Username", user.Username);
                        command.Parameters.AddWithValue("@Password", user.Password);
                        command.Parameters.AddWithValue("@Phone", user.Phone);
                        command.Parameters.AddWithValue("@Email", user.Email);
                        command.Parameters.AddWithValue("@Status", user.Status);
                        command.Parameters.AddWithValue("@Role", user.Role);

                        id = (Guid)command.ExecuteScalar();                        
                    }
                }

            /*
              Entendo que seguindo os padrões do Entity seria

            _context.Users.Add(user);
            _context.SaveChanges();

            Porém o Migrator não reconheceu meu usuário do banco local, 
            impedindo minha conexão, então fiz do modo tradicional acima
            para entregar a tempo o teste

             */

            return id;
        }
        catch (Exception ex)
        {
            return Guid.Empty;
        }
    }

    /// <summary>
    /// Retrieves a user by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user if found, null otherwise</returns>
    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Users.FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }

    /// <summary>
    /// Retrieves a user by their email address
    /// </summary>
    /// <param name="email">The email address to search for</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user if found, null otherwise</returns>
    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

    /// <summary>
    /// Deletes a user from the database
    /// </summary>
    /// <param name="id">The unique identifier of the user to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the user was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await GetByIdAsync(id, cancellationToken);
        if (user == null)
            return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
