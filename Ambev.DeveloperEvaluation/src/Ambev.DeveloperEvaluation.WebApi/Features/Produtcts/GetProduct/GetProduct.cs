using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

/// <summary>
/// Profile for mapping GerProduct feature requests to commands
/// </summary>
public class GetProduct : Profile
{
    /// <summary>
    /// Initializes the mappings for GerProduct feature
    /// </summary>
    public GetProduct()
    {
        CreateMap<Guid, Application.Products.GetProduct.GetProductCommand>()
            .ConstructUsing(id => new Application.Products.GetProduct.GetProductCommand(id));
    }
}
