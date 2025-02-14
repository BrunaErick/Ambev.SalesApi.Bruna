using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

/// <summary>
/// Profile for mapping between User entity and GetUserResponse
/// </summary>
public class GetCart : Profile
{
    /// <summary>
    /// Initializes the mappings for GetUser operation
    /// </summary>
    public GetCart()
    {
        CreateMap<Cart, GetCartResult>();
    }
}
