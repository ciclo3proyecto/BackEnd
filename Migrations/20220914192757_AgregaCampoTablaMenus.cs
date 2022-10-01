using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.Api.Migrations
{
    public partial class AgregaCampoTablaMenus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "menu",
                table: "menus");

            migrationBuilder.AlterColumn<decimal>(
                name: "identificacion",
                table: "usuarios",
                type: "decimal(28)",
                precision: 28,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,30)",
                oldPrecision: 28,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "ruta",
                keyValue: null,
                column: "ruta",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ruta",
                table: "menus",
                type: "varchar(500)",
                maxLength: 500,
                nullable: false,
                collation: "utf8_unicode_ci",
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8")
                .OldAnnotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "estado",
                keyValue: null,
                column: "estado",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "estado",
                table: "menus",
                type: "varchar(13)",
                maxLength: 13,
                nullable: false,
                collation: "utf8_unicode_ci",
                oldClrType: typeof(string),
                oldType: "varchar(13)",
                oldMaxLength: 13,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8")
                .OldAnnotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "eliminado",
                table: "menus",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "menus",
                keyColumn: "descripcion",
                keyValue: null,
                column: "descripcion",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "menus",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                collation: "utf8_unicode_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8")
                .OldAnnotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.AlterColumn<int>(
                name: "creadopor",
                table: "menus",
                type: "int(11)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int(11)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "creado",
                table: "menus",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "actualizado",
                table: "menus",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Opcion",
                table: "menus",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                collation: "utf8_unicode_ci")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.AddColumn<int>(
                name: "PadreId",
                table: "menus",
                type: "int(11)",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Opcion",
                table: "menus");

            migrationBuilder.DropColumn(
                name: "PadreId",
                table: "menus");

            migrationBuilder.AlterColumn<decimal>(
                name: "identificacion",
                table: "usuarios",
                type: "decimal(28,30)",
                precision: 28,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(28)",
                oldPrecision: 28,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ruta",
                table: "menus",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true,
                collation: "utf8_unicode_ci",
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500)
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8")
                .OldAnnotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.AlterColumn<string>(
                name: "estado",
                table: "menus",
                type: "varchar(13)",
                maxLength: 13,
                nullable: true,
                collation: "utf8_unicode_ci",
                oldClrType: typeof(string),
                oldType: "varchar(13)",
                oldMaxLength: 13)
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8")
                .OldAnnotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "eliminado",
                table: "menus",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "menus",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                collation: "utf8_unicode_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8")
                .OldAnnotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.AlterColumn<int>(
                name: "creadopor",
                table: "menus",
                type: "int(11)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int(11)");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "creado",
                table: "menus",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "actualizado",
                table: "menus",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "menu",
                table: "menus",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                collation: "utf8_unicode_ci")
                .Annotation("MySql:CharSet", "utf8");
        }
    }
}
