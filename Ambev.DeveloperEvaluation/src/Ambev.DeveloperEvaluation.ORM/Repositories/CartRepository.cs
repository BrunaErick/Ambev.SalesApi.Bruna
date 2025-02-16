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
/// Implementation of ICartRepository using Entity Framework Core
/// </summary>
public class CartRepository : ICartRepository
{
    private readonly DefaultContext _context;
    private readonly IConfiguration _appSettings;

    /// <summary>
    /// Initializes a new instance of CartRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public CartRepository(DefaultContext context, IConfiguration appSettings)
    {
        _context = context;
        _appSettings = appSettings;
    }

    /// <summary>
    /// Creates a new Cart in the database
    /// </summary>
    /// <param name="Cart">The Cart to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created Cart</returns>
    public async Task<Guid> CreateAsync(Cart Cart, CancellationToken cancellationToken = default)
    {
        var connectionstring = _appSettings.GetConnectionString("DefaultConnection");
        var id = new Guid();
        try
        {
            var sqlQuery = @" Insert into  [AmbevDb].[dbo].[Carts] 
            (
                [Cartname] 
                ,[Password] 
                ,[Phone] 
                ,[Email] 
                ,[Status]  
                ,[Role]
            ) 
            OUTPUT INSERTED.Id
             values(
                @Cartname
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
                        command.Parameters.AddWithValue("@Password", Cart.Password);
                        command.Parameters.AddWithValue("@Phone", Cart.Phone);
                        command.Parameters.AddWithValue("@Role", Cart.Role);

                        id = (Guid)command.ExecuteScalar();                        
                    }
                }

            /*
              Entendo que seguindo os padrões do Entity seria

            _context.Carts.Add(Cart);
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
    /// Retrieves a Cart by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the Cart</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Cart if found, null otherwise</returns>
    public async Task<Cart?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Carts.FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }


    /// <summary>
    /// Deletes a Cart from the database
    /// </summary>
    /// <param name="id">The unique identifier of the Cart to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the Cart was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var Cart = await GetByIdAsync(id, cancellationToken);
        if (Cart == null)
            return false;

        _context.Carts.Remove(Cart);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
