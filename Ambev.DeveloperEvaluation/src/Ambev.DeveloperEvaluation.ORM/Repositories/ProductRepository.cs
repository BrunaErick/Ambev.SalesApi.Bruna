using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Azure.Core;
using Dapper;
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
    public async Task<int> CreateAsync(Product Product, CancellationToken cancellationToken = default)
    {
        /*
              Entendo que seguindo os padrões do Entity seria

            _context.Products.Add(Product);
            _context.SaveChanges();

            Porém o Migrator não reconheceu meu usuário do banco local, 
            impedindo minha conexão, então fiz do modo tradicional abaixo
            para entregar a tempo o teste funcionando

             */

        var connectionstring = _appSettings.GetConnectionString("DefaultConnection");
        var id = 0;
        try
        {
            var sqlQuery = @" Insert into  [AmbevDb].[dbo].[Products] 
           ([Title]
           ,[Price]
           ,[Description]
           ,[Category]
           ,[Image]
           ,[RatingRate]
           ,[RatingCount])

            OUTPUT INSERTED.Id
             values(
                @Title
                ,@Price
                ,@Description
                ,@Category
                ,@Image
                ,@RatingRate
                ,@RatingCount)";

                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Title", Product.Title);
                        command.Parameters.AddWithValue("@Price", Product.Price);
                        command.Parameters.AddWithValue("@Description", Product.Description);
                        command.Parameters.AddWithValue("@Category", Product.Category);
                        command.Parameters.AddWithValue("@Image", Product.Image);
                        command.Parameters.AddWithValue("@RatingRate", Product.RatingRate);
                        command.Parameters.AddWithValue("@RatingCount", Product.RatingCount);

                    id = (int)command.ExecuteScalar();                        
                    }
                }

            return id;
        }
        catch (Exception ex)
        {
            return 0;
        }
    }

    /// <summary>
    /// Retrieves a Product by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the Product</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Product if found, null otherwise</returns>
    public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        //   return await _context.Products.FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);

        var response = new Product();

        var connectionstring = _appSettings.GetConnectionString("DefaultConnection");

        try
        {
            var sqlQuery = @" SELECT
           [Title]
           ,[Price]
           ,[Description]
           ,[Category]
           ,[Image]
           ,[RatingRate]
           ,[RatingCount]
            FROM  [AmbevDb].[dbo].[Products] 
            WHERE [ID] = @id";

            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                // Usando Dapper para executar a consulta e mapear o resultado para um objeto User
                response = connection.QuerySingleOrDefault<Product>(sqlQuery, new { id });
                response.Id = id;
            }

            return response;
        }
        catch (Exception ex)
        {
            //ira retornar o usuario vazio
        }

        return response;
    }

   

    /// <summary>
    /// Deletes a Product from the database
    /// </summary>
    /// <param name="id">The unique identifier of the Product to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the Product was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var connectionstring = _appSettings.GetConnectionString("DefaultConnection");

        var sqlQuery = @"
        DELETE FROM [AmbevDb].[dbo].[Products]
        WHERE [iD] = @id";

        using (var connection = new SqlConnection(connectionstring))
        {
            connection.Open();

            // Usando Dapper para executar a consulta de deleção
            int rowsAffected = connection.Execute(sqlQuery, new { id });

            // Verifica se a exclusão foi bem-sucedida (caso o número de linhas afetadas seja 1)
            return rowsAffected > 0;
        }
    }
}
