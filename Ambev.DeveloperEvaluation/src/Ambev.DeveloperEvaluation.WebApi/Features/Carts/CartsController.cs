using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.DeleteCart;
using Ambev.DeveloperEvaluation.Application.Carts.GetCart;
using Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts
{
    /// <summary>
    /// Controller for managing Cart operations
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CartsController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ICartBusiness _business;

        /// <summary>
        /// Initializes a new instance of CartsController
        /// </summary>
        /// <param name="mediator">The mediator instance</param>
        /// <param name="mapper">The AutoMapper instance</param>
        /// <param name="business">The CartBusiness instance</param>
        public CartsController(IMediator mediator, IMapper mapper, ICartBusiness business)
        {
            _mediator = mediator;
            _mapper = mapper;
            _business = business;
        }

        /// <summary>
        /// Creates a new Cart
        /// </summary>
        /// <param name="request">The Cart creation request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created Cart details</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateCartResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCart([FromBody] CreateCartRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<Cart>(request);

            var response = _business.CreateAsync(command, cancellationToken);
            if (response.Result > 0)
            {
                command.Id = (int)response.Result;
                return Created(string.Empty, new ApiResponseWithData<CreateCartResponse>
                {
                    Success = true,
                    Message = "Cart created successfully",
                    Data = _mapper.Map<CreateCartResponse>(command)
                });
            }
            else
                return Conflict(new ApiResponseWithData<CreateCartResponse>
                {
                    Success = false,
                    Message = "Error",
                    Data = _mapper.Map<CreateCartResponse>(command)
                });
        }

        /// <summary>
        /// Retrieves a Cart by their ID
        /// </summary>
        /// <param name="id">The unique identifier of the Cart</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Cart details if found</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetCartResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCart([FromRoute] int id, CancellationToken cancellationToken)
        {
            var request = new GetCartRequest { Id = id };
            var validator = new GetCartRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<GetCartCommand>(request.Id);
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<GetCartResponse>
            {
                Success = true,
                Message = "Cart retrieved successfully",
                Data = _mapper.Map<GetCartResponse>(response)
            });
        }

        /// <summary>
        /// Deletes a Cart by their ID
        /// </summary>
        /// <param name="id">The unique identifier of the Cart to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Success response if the Cart was deleted</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCart([FromRoute] int id, CancellationToken cancellationToken)
        {
            var request = new DeleteCartRequest { Id = id };
            //var validator = new DeleteCartRequestValidator();
            //var validationResult = await validator.ValidateAsync(request, cancellationToken);

            //if (!validationResult.IsValid)
            //    return BadRequest(validationResult.Errors);

            var command = _mapper.Map<DeleteCartCommand>(request.Id);
            await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Cart deleted successfully"
            });
        }

    }
}
