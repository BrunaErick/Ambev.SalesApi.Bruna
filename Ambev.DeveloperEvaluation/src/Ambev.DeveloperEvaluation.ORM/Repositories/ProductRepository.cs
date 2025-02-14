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
/// Implementation of IProductRepository using Entity Framework Core
/// </summary>
public class ProductRepository : IProductRepository
{
    private readonly DefaultContext _context;
    private readonly IConfiguration _appSettings;

    /// <summary>
    /// Initializes a new instance of ProductRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public ProductRepository(DefaultContext context, IConfiguration appSettings)
    {
        _context = context;
        _appSettings = appSettings;
    }

    /// <summary>
    /// Creates a new Product in the database
    /// </summary>
    /// <param name="Product">The Product to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created Product</returns>
    public async Task<Guid> CreateAsync(Product Product, CancellationToken cancellationToken = default)
    {
        var connectionstring = _appSettings.GetConnectionString("DefaultConnection");
        var id = new Guid();
        try
        {
            var sqlQuery = @" Insert into  [AmbevDb].[dbo].[Products] 
            (
                [Productname] 
                ,[Password] 
                ,[Phone] 
                ,[Email] 
                ,[Status]  
                ,[Role]
            ) 
            OUTPUT INSERTED.Id
             values(
                @Productname
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
                        command.Parameters.AddWithValue("@Password", Product.Password);
                        command.Parameters.AddWithValue("@Phone", Product.Phone);
                        command.Parameters.AddWithValue("@Email", Product.Email);
                        command.Parameters.AddWithValue("@Status", Product.Status);
                        command.Parameters.AddWithValue("@Role", Product.Role);

                        id = (Guid)command.ExecuteScalar();                        
                    }
                }

            /*
              Entendo que seguindo os padrões do Entity seria

            _context.Products.Add(Product);
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
    /// Retrieves a Product by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the Product</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Product if found, null otherwise</returns>
    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Products.FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }

    /// <summary>
    /// Retrieves a Product by their email address
    /// </summary>
    /// <param name="email">The email address to search for</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Product if found, null otherwise</returns>
    public async Task<Product?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _context.Products
            .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

    /// <summary>
    /// Deletes a Product from the database
    /// </summary>
    /// <param name="id">The unique identifier of the Product to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the Product was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var Product = await GetByIdAsync(id, cancellationToken);
        if (Product == null)
            return false;

        _context.Products.Remove(Product);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
