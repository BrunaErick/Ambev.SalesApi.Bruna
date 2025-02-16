using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


/// <summary>
/// Represents a cart in the system with authentication and profile information.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Cart : BaseEntity, ICart
{
    /// <summary>
    /// Gets the cart's full name.
    /// Must not be null or empty and should contain both first and last names.
    /// </summary>
    public string Cartname { get; set; } = string.Empty;

    /// <summary>
    /// Gets the cart's role.
    /// </summary>
    public string Role { get; set; } = string.Empty;

    /// <summary>
    /// Gets the cart's phone number.
    /// Must be a valid phone number format following the pattern (XX) XXXXX-XXXX.
    /// </summary>
    public string Phone { get; set; } = string.Empty ;

    /// <summary>
    /// Gets the hashed password for authentication.
    /// Password must meet security requirements: minimum 8 characters, at least one uppercase letter,
    /// one lowercase letter, one number, and one special character.
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Gets the unique identifier of the cart.
    /// </summary>
    /// <returns>The cart's ID as a string.</returns>
    string ICart.Id => Id.ToString();

    
    /// <summary>
    /// Initializes a new instance of the cart class.
    /// </summary>
    //public cart()
    //{
    //    CreatedAt = DateTime.UtcNow;
    //}

    /// <summary>
    /// Performs validation of the cart entity using the cartValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">cartname format and length</list>
    /// <list type="bullet">Email format</list>
    /// <list type="bullet">Phone number format</list>
    /// <list type="bullet">Password complexity requirements</list>
    /// <list type="bullet">Role validity</list>
    /// 
    

    /// <summary>
    /// Activates the cart account.
    /// Changes the cart's status to Active.
    /// </summary>
    //public void Activate()
    //{
    //    Status = cartStatus.Active;
    //    UpdatedAt = DateTime.UtcNow;
    //}

    ///// <summary>
    ///// Deactivates the cart account.
    ///// Changes the cart's status to Inactive.
    ///// </summary>
    //public void Deactivate()
    //{
    //    Status = cartStatus.Inactive;
    //    UpdatedAt = DateTime.UtcNow;
    //}

    /// <summary>
    /// Blocks the cart account.
    /// Changes the cart's status to Blocked.
    /// </summary>
    
}