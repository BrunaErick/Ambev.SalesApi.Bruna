using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

/// <summary>
/// Command for retrieving a GerProduct by their ID
/// </summary>
public record GetProductCommand : IRequest<GetProductResult>
{
    /// <summary>
    /// The unique identifier of the GerProduct to retrieve
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Initializes a new instance of GetGerProductCommand
    /// </summary>
    /// <param name="id">The ID of the GerProduct to retrieve</param>
    public GetProductCommand(int id)
    {
        Id = id;
    }
}
