using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Profile for mapping between User entity and CreateUserResponse
/// </summary>
public class CreateProduct : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public CreateProduct()
    {
        CreateMap<CreateProductCommand, User>();
        CreateMap<User, CreateProductResult>();
    }
}
