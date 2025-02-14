using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

/// <summary>
/// Profile for mapping between User entity and GetUserResponse
/// </summary>
public class GetProduct : Profile
{
    /// <summary>
    /// Initializes the mappings for GetUser operation
    /// </summary>
    public GetProduct()
    {
        CreateMap<User, GetProductResult>();
    }
}
