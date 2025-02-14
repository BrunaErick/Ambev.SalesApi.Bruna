using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

/// <summary>
/// Profile for mapping between Cart entity and GetCartResponse
/// </summary>
public class GetCart : Profile
{
    /// <summary>
    /// Initializes the mappings for GetCart operation
    /// </summary>
    public GetCart()
    {
        CreateMap<Cart, GetCartResult>();
    }
}
