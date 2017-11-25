using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Unsch.Web.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_PLANTA",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    CLASE = table.Column<string>(maxLength: 200, nullable: true),
                    DESCRIPCION = table.Column<string>(maxLength: 800, nullable: true),
                    DIVISION = table.Column<string>(maxLength: 200, nullable: true),
                    ESPECIE = table.Column<string>(maxLength: 200, nullable: true),
                    FAMILIA = table.Column<string>(maxLength: 200, nullable: true),
                    FECHA = table.Column<string>(maxLength: 100, nullable: true),
                    GENERO = table.Column<string>(maxLength: 200, nullable: true),
                    IMAGEN_BASE64 = table.Column<string>(nullable: false),
                    NOMBRE_ARCHIVO = table.Column<string>(maxLength: 100, nullable: false),
                    NOMBRE_PLANTA = table.Column<string>(maxLength: 200, nullable: false),
                    ORDEN = table.Column<string>(maxLength: 200, nullable: true),
                    REINO = table.Column<string>(maxLength: 200, nullable: true),
                    SUB_CLASE = table.Column<string>(maxLength: 200, nullable: true),
                    SUB_FAMILIA = table.Column<string>(maxLength: 200, nullable: true),
                    TRIBU = table.Column<string>(maxLength: 200, nullable: true),
                    UBICACION = table.Column<string>(maxLength: 200, nullable: true),
                    USURARIO_ID = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PLANTA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "T_USUARIO",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    EMAIL = table.Column<string>(maxLength: 100, nullable: false),
                    IMAGE = table.Column<string>(nullable: false),
                    NOMBRES = table.Column<string>(maxLength: 200, nullable: false),
                    PASSWORD = table.Column<string>(maxLength: 100, nullable: false),
                    USER_NAME = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_USUARIO", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_PLANTA");

            migrationBuilder.DropTable(
                name: "T_USUARIO");
        }
    }
}
