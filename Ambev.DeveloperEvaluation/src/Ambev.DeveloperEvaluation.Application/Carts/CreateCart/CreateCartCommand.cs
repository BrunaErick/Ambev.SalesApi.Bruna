using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

/// <summary>
/// Command for creating a new cart.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a cart, 
/// including cartname, password, phone number, email, status, and role. 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="CreatecartResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="CreatecartCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class CreateCartCommand : IRequest<CreateCartResult>
{
    /// <summary>
    /// Gets or sets the cartname of the cart to be created.
    /// </summary>
    public string cartname { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the password for the cart.
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the phone number for the cart.
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address for the cart.
    /// </summary>
    public string Email { get; set; } = string.Empty;
    

    public ValidationResultDetail Validate()
    {
        var validator = new CreateCartCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}