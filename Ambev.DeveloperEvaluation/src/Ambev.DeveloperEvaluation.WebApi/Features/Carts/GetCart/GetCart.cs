using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;

/// <summary>
/// Profile for mapping GetCart feature requests to commands
/// </summary>
public class GetCart : Profile
{
    /// <summary>
    /// Initializes the mappings for GetCart feature
    /// </summary>
    public GetCart()
    {
        CreateMap<Guid, Application.Carts.GetCart.GetCartCommand>()
            .ConstructUsing(id => new Application.Carts.GetCart.GetCartCommand(id));
    }
}
