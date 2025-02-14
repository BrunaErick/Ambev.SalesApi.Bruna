using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Profile for mapping between User entity and CreateProductResponse
/// </summary>
public class CreateProduct : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateProduct operation
    /// </summary>
    public CreateProduct()
    {
        CreateMap<CreateProductCommand, User>();
        CreateMap<User, CreateProductResult>();
    }
}
