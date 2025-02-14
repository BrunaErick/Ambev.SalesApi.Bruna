using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

/// <summary>
/// Profile for mapping between User entity and GerProductResponse
/// </summary>
public class GetProduct : Profile
{
    /// <summary>
    /// Initializes the mappings for GerProduct operation
    /// </summary>
    public GetProduct()
    {
        CreateMap<User, GetProductResult>();
    }
}
