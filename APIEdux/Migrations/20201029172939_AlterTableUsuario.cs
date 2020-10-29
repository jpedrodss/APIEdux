using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIEdux.Migrations
{
    public partial class AlterTableUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "DataUltimoAcesso",
                table: "Usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Usuario",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataUltimoAcesso",
                table: "Usuario",
                type: "datetime",
                nullable: true);
        }
    }
}
