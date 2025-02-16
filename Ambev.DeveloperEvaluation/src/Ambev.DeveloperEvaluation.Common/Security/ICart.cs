namespace Ambev.DeveloperEvaluation.Common.Security
{
    /// <summary>
    /// Define o contrato para representação de um carrinho no sistema.
    /// </summary>
    public interface ICart
    {
        /// <summary>
        /// Gets the unique identifier of the cart
        public int Id { get; set; }

        /// <summary>
        /// Gets the cart's userId
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets the Date
        /// </summary>
        public DateTime Date { get; set; }
    }
}
