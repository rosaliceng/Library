using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryWebAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    PublisherId = table.Column<int>(nullable: false),
                    Launch = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    TotalRented = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    RentDate = table.Column<DateTime>(nullable: false),
                    ForecastDate = table.Column<DateTime>(nullable: false),
                    DevolutionDate = table.Column<DateTime>(nullable: false),
                    ReturnedBook = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rents_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "City", "Name" },
                values: new object[,]
                {
                    { 1, "São Paulo", "Saraiva" },
                    { 2, "Rio de Janeiro", "Intríseca" },
                    { 3, "Fortaleza", "Arqueiro" },
                    { 4, "Fortaleza", "Bem me quer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "Rua A", "Fortaleza", "rosa@gmail.com", "Rosa" },
                    { 2, "Rua B", "Caucaia", "alice@gmail.com", "Alice" },
                    { 3, "Rua C", "Fortaleza", "andre@gmail.com", "André" },
                    { 4, "Rua D", "Fortaleza", "naua@gmail.com", "Nauã" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Launch", "Name", "PublisherId", "Quantity", "TotalRented" },
                values: new object[,]
                {
                    { 1, "Jk Rowling", new DateTime(2000, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter e o Cálice de fogo", 1, 10, 23 },
                    { 4, "Rick Riordan", new DateTime(2005, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Percy Jackson e o Ladrão de raios", 2, 3, 23 },
                    { 2, "Drauzio Varella", new DateTime(1999, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Estação Carandiru", 3, 68, 90 },
                    { 3, "Antoine de Saint-Exupéry", new DateTime(1943, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "O pequeno príncipe", 4, 10, 36 }
                });

            migrationBuilder.InsertData(
                table: "Rents",
                columns: new[] { "Id", "BookId", "DevolutionDate", "ForecastDate", "RentDate", "ReturnedBook", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1 },
                    { 3, 4, new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4 },
                    { 4, 2, new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3 },
                    { 2, 3, new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_BookId",
                table: "Rents",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_UserId",
                table: "Rents",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
