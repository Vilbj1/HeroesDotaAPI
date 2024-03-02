using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroesDota.Migrations
{
    /// <inheritdoc />
    public partial class VinculoFuncaoHeroi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HeroId",
                table: "Funcao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Funcao_HeroId",
                table: "Funcao",
                column: "HeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcao_Herois_HeroId",
                table: "Funcao",
                column: "HeroId",
                principalTable: "Herois",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcao_Herois_HeroId",
                table: "Funcao");

            migrationBuilder.DropIndex(
                name: "IX_Funcao_HeroId",
                table: "Funcao");

            migrationBuilder.DropColumn(
                name: "HeroId",
                table: "Funcao");
        }
    }
}
