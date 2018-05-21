using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Quick_Application1.Migrations
{
    public partial class primerMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bancos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    deleted = table.Column<bool>(nullable: false),
                    descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bancos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "cambiodolarhistorial",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    compra = table.Column<decimal>(nullable: false),
                    fecha = table.Column<DateTime>(nullable: false),
                    venta = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cambiodolarhistorial", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "categoriacuenta",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    deleted = table.Column<bool>(nullable: false),
                    descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoriacuenta", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "cheque",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    beneficiario = table.Column<string>(nullable: true),
                    concepto = table.Column<string>(nullable: true),
                    deleted = table.Column<bool>(nullable: false),
                    estado = table.Column<bool>(nullable: false),
                    fecha = table.Column<DateTime>(nullable: false),
                    fechaTransaccion = table.Column<DateTime>(nullable: false),
                    idUsuario = table.Column<int>(nullable: false),
                    monto = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cheque", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "chequera",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    deleted = table.Column<bool>(nullable: false),
                    fechaUltimoMovimiento = table.Column<DateTime>(nullable: false),
                    idCuenta = table.Column<int>(nullable: false),
                    numeroCheque_Inicial = table.Column<int>(nullable: false),
                    numeroCheque_final = table.Column<int>(nullable: false),
                    numeroChequera = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chequera", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "cuentacontable",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<string>(nullable: true),
                    deleted = table.Column<bool>(nullable: false),
                    descripcion = table.Column<string>(nullable: true),
                    idCategoria = table.Column<int>(nullable: false),
                    idCuentaPadre = table.Column<int>(nullable: false),
                    idMoneda = table.Column<int>(nullable: false),
                    idNaturaleza = table.Column<int>(nullable: false),
                    idnivel = table.Column<int>(nullable: false),
                    inicioVigencia = table.Column<DateTime>(nullable: false),
                    prefijo = table.Column<string>(nullable: true),
                    version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cuentacontable", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "documento",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<string>(nullable: true),
                    deleted = table.Column<bool>(nullable: false),
                    descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documento", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "factura",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaFactura = table.Column<DateTime>(nullable: false),
                    cantidad = table.Column<decimal>(nullable: false),
                    deleted = table.Column<bool>(nullable: false),
                    descuento = table.Column<decimal>(nullable: false),
                    exento = table.Column<bool>(nullable: false),
                    fechaFinal = table.Column<DateTime>(nullable: false),
                    fechaInicio = table.Column<DateTime>(nullable: false),
                    idCuenta = table.Column<int>(nullable: false),
                    idUsuario = table.Column<int>(nullable: false),
                    impuesto = table.Column<decimal>(nullable: false),
                    otrosCargos = table.Column<decimal>(nullable: false),
                    subTotal = table.Column<decimal>(nullable: false),
                    valor = table.Column<decimal>(nullable: false),
                    valorUnitario = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_factura", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "moneda",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cambiadoa = table.Column<string>(nullable: true),
                    compra = table.Column<decimal>(nullable: false),
                    deleted = table.Column<bool>(nullable: false),
                    descripcion = table.Column<string>(nullable: true),
                    simbolo = table.Column<string>(nullable: true),
                    venta = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moneda", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "naturalezacuenta",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    deleted = table.Column<bool>(nullable: false),
                    descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_naturalezacuenta", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "nivelcuenta",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    deleted = table.Column<bool>(nullable: false),
                    descripcion = table.Column<string>(nullable: true),
                    nivel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nivelcuenta", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bancos");

            migrationBuilder.DropTable(
                name: "cambiodolarhistorial");

            migrationBuilder.DropTable(
                name: "categoriacuenta");

            migrationBuilder.DropTable(
                name: "cheque");

            migrationBuilder.DropTable(
                name: "chequera");

            migrationBuilder.DropTable(
                name: "cuentacontable");

            migrationBuilder.DropTable(
                name: "documento");

            migrationBuilder.DropTable(
                name: "factura");

            migrationBuilder.DropTable(
                name: "moneda");

            migrationBuilder.DropTable(
                name: "naturalezacuenta");

            migrationBuilder.DropTable(
                name: "nivelcuenta");
        }
    }
}
