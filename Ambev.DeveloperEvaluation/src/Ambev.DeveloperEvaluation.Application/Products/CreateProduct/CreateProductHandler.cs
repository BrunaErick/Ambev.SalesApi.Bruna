using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Security;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Handler for processing CreateProductCommand requests
/// </summary>
public class CreateProductHandler 
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;

    /// <summary>
    /// Initializes a new instance of CreateProductHandler
    /// </summary>
    /// <param name="f">The product repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateProductCommand</param>
    public CreateProductHandler(IProductRepository productRepository, IMapper mapper, IPasswordHasher passwordHasher)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

   
}
