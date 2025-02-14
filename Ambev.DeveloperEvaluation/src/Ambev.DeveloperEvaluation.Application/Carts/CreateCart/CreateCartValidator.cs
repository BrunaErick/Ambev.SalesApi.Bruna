using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

/// <summary>
/// Validator for CreatecartCommand that defines validation rules for cart creation command.
/// </summary>
public class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreatecartCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Email: Must be in valid format (using EmailValidator)
    /// - cartname: Required, must be between 3 and 50 characters
    /// - Password: Must meet security requirements (using PasswordValidator)
    /// - Phone: Must match international format (+X XXXXXXXXXX)
    /// - Status: Cannot be set to Unknown
    /// - Role: Cannot be set to None
    /// </remarks>
    public CreateCartCommandValidator()
    {
        RuleFor(cart => cart.Email).SetValidator(new EmailValidator());
        RuleFor(cart => cart.cartname).NotEmpty().Length(3, 50);
        RuleFor(cart => cart.Password).SetValidator(new PasswordValidator());
        RuleFor(cart => cart.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
    }
}