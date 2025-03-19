using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioPrueba.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Nombre", "Descripcion", "Precio", "Cantidad" },
                values: new object[,]
                {
            { "Producto A", "Descripción del producto A", 50.00, 20 },
            { "Producto B", "Descripción del producto B", 100.00, 15 }
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Productos");
        }
    }
}
