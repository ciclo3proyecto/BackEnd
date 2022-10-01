using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.Api.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "menus",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    menu = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    descripcion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    ruta = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    estado = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: true, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    creadopor = table.Column<int>(type: "int(11)", nullable: true),
                    creado = table.Column<DateOnly>(type: "date", nullable: true),
                    actualizadopor = table.Column<int>(type: "int(11)", nullable: true),
                    actualizado = table.Column<DateOnly>(type: "date", nullable: true),
                    eliminadopor = table.Column<int>(type: "int(11)", nullable: true),
                    eliminado = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menus", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "perfiles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    estado = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: true, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    creadopor = table.Column<int>(type: "int(11)", nullable: true),
                    creado = table.Column<DateOnly>(type: "date", nullable: true),
                    actualizadopor = table.Column<int>(type: "int(11)", nullable: true),
                    actualizado = table.Column<DateOnly>(type: "date", nullable: true),
                    eliminadopor = table.Column<int>(type: "int(11)", nullable: true),
                    eliminado = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfiles", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "tiposdocumentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    estado = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: true, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    creadopor = table.Column<int>(type: "int(11)", nullable: true),
                    creado = table.Column<DateOnly>(type: "date", nullable: true),
                    actualizadopor = table.Column<int>(type: "int(11)", nullable: true),
                    actualizado = table.Column<DateOnly>(type: "date", nullable: true),
                    eliminadopor = table.Column<int>(type: "int(11)", nullable: true),
                    eliminado = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tiposdocumentos", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "unidades",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    estado = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: true, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    creadopor = table.Column<int>(type: "int(11)", nullable: true),
                    creado = table.Column<DateOnly>(type: "date", nullable: true),
                    actualizadopor = table.Column<int>(type: "int(11)", nullable: true),
                    actualizado = table.Column<DateOnly>(type: "date", nullable: true),
                    eliminadopor = table.Column<int>(type: "int(11)", nullable: true),
                    eliminado = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidades", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "permisos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    menus_id = table.Column<int>(type: "int(11)", nullable: false),
                    perfil_id = table.Column<int>(type: "int(11)", nullable: false),
                    estado = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: true, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    creadopor = table.Column<int>(type: "int(11)", nullable: true),
                    creado = table.Column<DateOnly>(type: "date", nullable: true),
                    actualizadopor = table.Column<int>(type: "int(11)", nullable: true),
                    actualizado = table.Column<DateOnly>(type: "date", nullable: true),
                    eliminadopor = table.Column<int>(type: "int(11)", nullable: true),
                    eliminado = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permisos", x => x.id);
                    table.ForeignKey(
                        name: "permisos_menus_fk",
                        column: x => x.menus_id,
                        principalTable: "menus",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "permisos_perfil_fk",
                        column: x => x.perfil_id,
                        principalTable: "perfiles",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    perfiles_id = table.Column<int>(type: "int(11)", nullable: false),
                    tiposdocumentos_id = table.Column<int>(type: "int(11)", nullable: false),
                    login = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    identificacion = table.Column<decimal>(type: "decimal(28)", precision: 28, nullable: true),
                    nombres = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    primerapellido = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    segundoapellido = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    estado = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: true, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    creadopor = table.Column<int>(type: "int(11)", nullable: true),
                    creado = table.Column<DateOnly>(type: "date", nullable: true),
                    actualizadopor = table.Column<int>(type: "int(11)", nullable: true),
                    actualizado = table.Column<DateOnly>(type: "date", nullable: true),
                    eliminadopor = table.Column<int>(type: "int(11)", nullable: true),
                    eliminado = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                    table.ForeignKey(
                        name: "usuarios_perfiles_fk",
                        column: x => x.perfiles_id,
                        principalTable: "perfiles",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "usuarios_tiposdocumentos_fk",
                        column: x => x.tiposdocumentos_id,
                        principalTable: "tiposdocumentos",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    unidades_id = table.Column<int>(type: "int(11)", nullable: false),
                    codigo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    descripcion = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    precio = table.Column<decimal>(type: "decimal(19,2)", precision: 19, scale: 2, nullable: true),
                    existencia = table.Column<decimal>(type: "decimal(19,2)", precision: 19, scale: 2, nullable: true),
                    estado = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: true, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    creadopor = table.Column<int>(type: "int(11)", nullable: false),
                    creado = table.Column<DateOnly>(type: "date", nullable: true),
                    actualizadopor = table.Column<int>(type: "int(11)", nullable: true),
                    actualizado = table.Column<DateOnly>(type: "date", nullable: true),
                    eliminadopor = table.Column<int>(type: "int(11)", nullable: true),
                    eliminado = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.id);
                    table.ForeignKey(
                        name: "productos_unidades_fk",
                        column: x => x.unidades_id,
                        principalTable: "unidades",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "productos_usuarios_fk",
                        column: x => x.creadopor,
                        principalTable: "usuarios",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "tiposmovimientos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    afectacion = table.Column<string>(type: "char(1)", fixedLength: true, maxLength: 1, nullable: true, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    estado = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: true, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    creadopor = table.Column<int>(type: "int(11)", nullable: false),
                    creado = table.Column<DateOnly>(type: "date", nullable: true),
                    actualizadopor = table.Column<int>(type: "int(11)", nullable: true),
                    actualizado = table.Column<DateOnly>(type: "date", nullable: true),
                    eliminadopor = table.Column<int>(type: "int(11)", nullable: true),
                    eliminado = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tiposmovimientos", x => x.id);
                    table.ForeignKey(
                        name: "tiposmovimientos_usuarios_fk",
                        column: x => x.creadopor,
                        principalTable: "usuarios",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "movimientos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    productos_id = table.Column<int>(type: "int(11)", nullable: false),
                    tiposmovimientos_id = table.Column<int>(type: "int(11)", nullable: false),
                    fecha = table.Column<DateOnly>(type: "date", nullable: true),
                    cantidad = table.Column<decimal>(type: "decimal(19,2)", precision: 19, scale: 2, nullable: true),
                    precio = table.Column<decimal>(type: "decimal(19,2)", precision: 19, scale: 2, nullable: true),
                    estado = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: true, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    creadopor = table.Column<int>(type: "int(11)", nullable: false),
                    creado = table.Column<DateOnly>(type: "date", nullable: true),
                    actualizadopor = table.Column<int>(type: "int(11)", nullable: true),
                    actualizado = table.Column<DateOnly>(type: "date", nullable: true),
                    eliminadopor = table.Column<int>(type: "int(11)", nullable: true),
                    eliminado = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimientos", x => x.id);
                    table.ForeignKey(
                        name: "movimientos_productos_fk",
                        column: x => x.productos_id,
                        principalTable: "productos",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "movimientos_tiposmovimientos_fk",
                        column: x => x.tiposmovimientos_id,
                        principalTable: "tiposmovimientos",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "movimientos_usuarios_fk",
                        column: x => x.creadopor,
                        principalTable: "usuarios",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateIndex(
                name: "movimientos_productos_fk",
                table: "movimientos",
                column: "productos_id");

            migrationBuilder.CreateIndex(
                name: "movimientos_tiposmovimientos_fk",
                table: "movimientos",
                column: "tiposmovimientos_id");

            migrationBuilder.CreateIndex(
                name: "movimientos_usuarios_fk",
                table: "movimientos",
                column: "creadopor");

            migrationBuilder.CreateIndex(
                name: "permisos_menus_fk",
                table: "permisos",
                column: "menus_id");

            migrationBuilder.CreateIndex(
                name: "permisos_perfil_fk",
                table: "permisos",
                column: "perfil_id");

            migrationBuilder.CreateIndex(
                name: "productos_unidades_fk",
                table: "productos",
                column: "unidades_id");

            migrationBuilder.CreateIndex(
                name: "productos_usuarios_fk",
                table: "productos",
                column: "creadopor");

            migrationBuilder.CreateIndex(
                name: "tiposmovimientos_usuarios_fk",
                table: "tiposmovimientos",
                column: "creadopor");

            migrationBuilder.CreateIndex(
                name: "usuarios_perfiles_fk",
                table: "usuarios",
                column: "perfiles_id");

            migrationBuilder.CreateIndex(
                name: "usuarios_tiposdocumentos_fk",
                table: "usuarios",
                column: "tiposdocumentos_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movimientos");

            migrationBuilder.DropTable(
                name: "permisos");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "tiposmovimientos");

            migrationBuilder.DropTable(
                name: "menus");

            migrationBuilder.DropTable(
                name: "unidades");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "perfiles");

            migrationBuilder.DropTable(
                name: "tiposdocumentos");
        }
    }
}
