using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Role = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                });

            migrationBuilder.CreateTable(
               name: "Products",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Title = table.Column<string>(nullable: false),
                   Price = table.Column<decimal>(nullable: false),
                   Description = table.Column<string>(nullable: true),
                   Category = table.Column<string>(nullable: true),
                   Image = table.Column<string>(nullable: true),
                   RatingRate = table.Column<decimal>(nullable: false),
                   RatingCount = table.Column<int>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Products", x => x.Id);
               });

            migrationBuilder.CreateTable(
               name: "Carts",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   UserId = table.Column<int>(nullable: false),
                   Date = table.Column<DateTime>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Carts", x => x.Id);
               });

            // Criação da tabela CartProducts com um campo de identidade como chave primária
            migrationBuilder.CreateTable(
                name: "CartProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),  // Auto incremento
                    CartId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    // Data opcional para adicionar quando o produto foi adicionado ao carrinho (exemplo)
                    AddedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    // Define 'Id' como chave primária
                    table.PrimaryKey("PK_CartProducts", x => x.Id);

                    // Não há chaves estrangeiras, apenas os campos CartId e ProductId são adicionados sem restrições
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
            name: "Products");

            migrationBuilder.DropTable(
            name: "Carts");

            migrationBuilder.DropTable(
                name: "CartProducts");
        }
    }
}
