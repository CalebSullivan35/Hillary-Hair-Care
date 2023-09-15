using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HillaryHairCare.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ServiceRate = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stylists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stylists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StylistId = table.Column<int>(type: "integer", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    AppointmentTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Stylists_StylistId",
                        column: x => x.StylistId,
                        principalTable: "Stylists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentService",
                columns: table => new
                {
                    AppointmentsId = table.Column<int>(type: "integer", nullable: false),
                    ServicesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentService", x => new { x.AppointmentsId, x.ServicesId });
                    table.ForeignKey(
                        name: "FK_AppointmentService_Appointments_AppointmentsId",
                        column: x => x.AppointmentsId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentService_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Kai Sa" },
                    { 2, "Yuumi" },
                    { 3, "Tahm Kench" },
                    { 4, "Janna" },
                    { 5, "Reneketon" },
                    { 6, "Ashe" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Name", "ServiceRate" },
                values: new object[,]
                {
                    { 1, "Basic Wash", 15.99m },
                    { 2, "You Stinky Wash", 25.99m },
                    { 3, "Green Dye", 22.49m },
                    { 4, "Quick Cut", 19.99m },
                    { 5, "Total Makeover", 74.99m },
                    { 6, "Kid Clip", 7.99m }
                });

            migrationBuilder.InsertData(
                table: "Stylists",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "Marissa Sullivan" },
                    { 2, true, "Joseph Pearson" },
                    { 3, false, "Chris Mills" },
                    { 4, true, "David TankTop" },
                    { 5, false, "Deanna David" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTime", "CustomerId", "StylistId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), 5, 2 },
                    { 2, new DateTime(2023, 9, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 3, new DateTime(2023, 9, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 4, new DateTime(2023, 9, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 5, new DateTime(2023, 9, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), 6, 5 }
                });

            migrationBuilder.InsertData(
                table: "AppointmentService",
                columns: new[] { "AppointmentsId", "ServicesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 1 },
                    { 4, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CustomerId",
                table: "Appointments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_StylistId",
                table: "Appointments",
                column: "StylistId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentService_ServicesId",
                table: "AppointmentService",
                column: "ServicesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentService");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Stylists");
        }
    }
}
