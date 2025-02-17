using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class GetProductRequestProfile : Profile
{
    public GetProductRequestProfile()
    {
        CreateMap<GetProductRequest, GetProductCommand>();
        CreateMap<GetProductResponse, Product>();
        CreateMap<Product, GetProductResponse>();
    }
}