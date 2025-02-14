using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.DeleteCart;

/// <summary>
/// Profile for mapping DeleteUser feature requests to commands
/// </summary>
public class DeleteCart : Profile
{
    /// <summary>
    /// Initializes the mappings for DeleteUser feature
    /// </summary>
    public DeleteCart()
    {
        CreateMap<Guid, Application.Carts.DeleteCart.DeleteCartCommand>()
            .ConstructUsing(id => new Application.Carts.DeleteCart.DeleteCartCommand(id));
    }
}
