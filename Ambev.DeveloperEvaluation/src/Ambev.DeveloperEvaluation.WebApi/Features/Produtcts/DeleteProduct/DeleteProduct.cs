using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct;

/// <summary>
/// Profile for mapping DeleteProduct feature requests to commands
/// </summary>
public class DeleteProduct : Profile
{
    /// <summary>
    /// Initializes the mappings for DeleteProduct feature
    /// </summary>
    public DeleteProduct()
    {
        CreateMap<Guid, Application.Products.DeleteProduct.DeleteProductCommand>()
            .ConstructUsing(id => new Application.Products.DeleteProduct.DeleteProductCommand(id));
    }
}
