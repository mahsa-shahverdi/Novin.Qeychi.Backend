using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Novin.Qeychi.Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BeautySalons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeautySalons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccessLevel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entrepreneurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccessLevel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrepreneurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccessLevel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stylists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccessLevel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stylists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfirmationWorkspaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessLicenseId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntrepreneurId = table.Column<int>(type: "int", nullable: false),
                    BeautySalonId = table.Column<int>(type: "int", nullable: false),
                    ImgForBusinessLicense = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ImgForEntrepreneurNationalCard = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ImgForOwnershipDocumentOrLease = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsVerify = table.Column<bool>(type: "bit", nullable: false),
                    LinkOfExclusivePanel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfirmationWorkspaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfirmationWorkspaces_BeautySalons_BeautySalonId",
                        column: x => x.BeautySalonId,
                        principalTable: "BeautySalons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfirmationWorkspaces_Entrepreneurs_EntrepreneurId",
                        column: x => x.EntrepreneurId,
                        principalTable: "Entrepreneurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConfirmationEmployments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeautySalonId = table.Column<int>(type: "int", nullable: false),
                    StylistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfirmationEmployments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfirmationEmployments_BeautySalons_BeautySalonId",
                        column: x => x.BeautySalonId,
                        principalTable: "BeautySalons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfirmationEmployments_Stylists_StylistId",
                        column: x => x.StylistId,
                        principalTable: "Stylists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConfirmationTurns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    BeautySalonId = table.Column<int>(type: "int", nullable: false),
                    StylistId = table.Column<int>(type: "int", nullable: false),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OndemandService = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deposit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPay = table.Column<bool>(type: "bit", nullable: false),
                    IsCancel = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfirmationTurns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfirmationTurns_BeautySalons_BeautySalonId",
                        column: x => x.BeautySalonId,
                        principalTable: "BeautySalons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfirmationTurns_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfirmationTurns_Stylists_StylistId",
                        column: x => x.StylistId,
                        principalTable: "Stylists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmationEmployments_BeautySalonId",
                table: "ConfirmationEmployments",
                column: "BeautySalonId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmationEmployments_StylistId",
                table: "ConfirmationEmployments",
                column: "StylistId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmationTurns_BeautySalonId",
                table: "ConfirmationTurns",
                column: "BeautySalonId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmationTurns_CustomerId",
                table: "ConfirmationTurns",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmationTurns_StylistId",
                table: "ConfirmationTurns",
                column: "StylistId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmationWorkspaces_BeautySalonId",
                table: "ConfirmationWorkspaces",
                column: "BeautySalonId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmationWorkspaces_EntrepreneurId",
                table: "ConfirmationWorkspaces",
                column: "EntrepreneurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfirmationEmployments");

            migrationBuilder.DropTable(
                name: "ConfirmationTurns");

            migrationBuilder.DropTable(
                name: "ConfirmationWorkspaces");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Stylists");

            migrationBuilder.DropTable(
                name: "BeautySalons");

            migrationBuilder.DropTable(
                name: "Entrepreneurs");
        }
    }
}
