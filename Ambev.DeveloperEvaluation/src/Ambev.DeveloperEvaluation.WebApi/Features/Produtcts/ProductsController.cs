using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Produtcts
{
    /// <summary>
    /// Controller for managing product operations
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : BaseController
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IProductBusiness _business;

        /// <summary>
        /// Initializes a new instance of ProductsController
        /// </summary>
        /// <param name="mediator">The mediator instance</param>
        /// <param name="mapper">The AutoMapper instance</param>
        /// <param name="business">The ProductBusiness instance</param>
        public ProductsController(IMediator mediator, IMapper mapper, IProductBusiness business)
        {
            _mediator = mediator;
            _mapper = mapper;
            _business = business;
        }

        /// <summary>
        /// Creates a new product
        /// </summary>
        /// <param name="request">The product creation request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created product details</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateProductResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<Product>(request);

            var response = _business.CreateAsync(command, cancellationToken);
            if (response.Result > 0)
            {
                command.Id = (int)response.Result;
                return Created(string.Empty, new ApiResponseWithData<CreateProductResponse>
                {
                    Success = true,
                    Message = "Product created successfully",
                    Data = _mapper.Map<CreateProductResponse>(command)
                });
            }
            else
                return Conflict(new ApiResponseWithData<CreateProductResponse>
                {
                    Success = false,
                    Message = "Error",
                    Data = _mapper.Map<CreateProductResponse>(command)
                });


        }

        /// <summary>
        /// Retrieves a Product by their ID
        /// </summary>
        /// <param name="id">The unique identifier of the Product</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Product details if found</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetProductResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProduct([FromRoute] int id, CancellationToken cancellationToken)
        {
            var response = _business.GetByIdAsync(id, cancellationToken);

            if (!string.IsNullOrEmpty(((Product)response.Result).Title))
                return Ok(new ApiResponseWithData<GetProductResponse>
                {
                    Success = true,
                    Message = "Product retrieved successfully",
                    Data = _mapper.Map<GetProductResponse>(response.Result)
                });
            else
                return NotFound(new ApiResponseWithData<GetProductResponse>
                {
                    Success = false,
                    Message = "Not Found",
                    Data = _mapper.Map<GetProductResponse>(response.Result)
                });
        }


        /// <summary>
        /// Retrieves all Products
        /// </summary>
        [HttpGet("GetAllProducts")]
        [ProducesResponseType(typeof(List<GetProductResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = _business.GetAllAsync(cancellationToken);

            if (((List<Product>)response.Result).Count > 0)
                return Ok(new ApiResponseWithData<List<GetProductResponse>>
                {
                    Success = true,
                    Message = "Product retrieved successfully",
                    Data = _mapper.Map<List<GetProductResponse>>(response.Result)
                });
            else
                return NotFound(new ApiResponseWithData<List<GetProductResponse>>
                {
                    Success = false,
                    Message = "Not Found",
                    Data = _mapper.Map<List<GetProductResponse>>(response.Result)
                });
        }



        /// <summary>
        /// Deletes a Product by their ID
        /// </summary>
        /// <param name = "id" > The unique identifier of the Product to delete</param>
        /// <param name = "cancellationToken" > Cancellation token</param>
        /// <returns>Success response if the Product was deleted</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id, CancellationToken cancellationToken)
        {
            var response = _business.DeleteAsync(id, cancellationToken);

            if (((Boolean)response.Result))
                return Ok(new ApiResponse
                {
                    Success = true,
                    Message = "Product deleted successfully"
                });
            else
                return BadRequest(new ApiResponseWithData<GetProductResult>
                {
                    Success = false,
                    Message = "Error"
                });
        }

    }
}
