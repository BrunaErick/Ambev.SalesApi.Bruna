﻿namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Represents the response returned after successfully creating a new product.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly created product,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class CreateProductResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the newly created product.
    /// </summary>
    /// <value>A Id that uniquely identifies the created product in the system.</value>
    public int Id { get; set; }
}
