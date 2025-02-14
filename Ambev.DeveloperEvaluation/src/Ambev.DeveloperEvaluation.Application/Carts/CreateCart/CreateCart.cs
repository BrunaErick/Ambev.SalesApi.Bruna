using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

/// <summary>
/// Profile for mapping between User entity and CreateUserResponse
/// </summary>
public class CreateCart : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public CreateCart()
    {
        CreateMap<CreateCartCommand, Cart>();
        CreateMap<Cart, CreateCartResult>();
    }
}
