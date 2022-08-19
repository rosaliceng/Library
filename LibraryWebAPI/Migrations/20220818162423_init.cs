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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    PublisherId = table.Column<int>(nullable: false),
                    Launch = table.Column<int>(nullable: false),
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
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    RentDate = table.Column<int>(nullable: false),
                    ForecastDate = table.Column<int>(nullable: false),
                    DevolutionDate = table.Column<int>(nullable: false)
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
                values: new object[] { 1, "São Paulo", "Saraiva" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "City", "Name" },
                values: new object[] { 2, "Rio de Janeiro", "Intríseca" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "City", "Name" },
                values: new object[] { 3, "Fortaleza", "Arqueiro" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "City", "Name" },
                values: new object[] { 4, "Fortaleza", "Bem me quer" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Email", "Name" },
                values: new object[] { 1, "Rua A", "Fortaleza", "rosa@gmail.com", "Rosa" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Email", "Name" },
                values: new object[] { 2, "Rua B", "Caucaia", "alice@gmail.com", "Alice" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Email", "Name" },
                values: new object[] { 3, "Rua C", "Fortaleza", "andre@gmail.com", "André" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Email", "Name" },
                values: new object[] { 4, "Rua D", "Fortaleza", "naua@gmail.com", "Nauã" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Launch", "Name", "PublisherId", "Quantity", "TotalRented" },
                values: new object[] { 1, "Jk Rowling", 23072001, "Harry Potter e o Cálice de fogo", 1, 10, 23 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Launch", "Name", "PublisherId", "Quantity", "TotalRented" },
                values: new object[] { 4, "Rick Riordan", 23072004, "Percy Jackson e o Ladrão de raios", 2, 3, 23 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Launch", "Name", "PublisherId", "Quantity", "TotalRented" },
                values: new object[] { 2, "Drauzio Varella", 8072001, "Estação Carandiru", 3, 68, 90 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Launch", "Name", "PublisherId", "Quantity", "TotalRented" },
                values: new object[] { 3, "Antoine de Saint-Exupéry", 23082001, "O pequeno príncipe", 4, 10, 36 });

            migrationBuilder.InsertData(
                table: "Rents",
                columns: new[] { "Id", "BookId", "DevolutionDate", "ForecastDate", "RentDate", "UserId" },
                values: new object[] { 1, 1, 26092022, 280920022, 20220923, 1 });

            migrationBuilder.InsertData(
                table: "Rents",
                columns: new[] { "Id", "BookId", "DevolutionDate", "ForecastDate", "RentDate", "UserId" },
                values: new object[] { 3, 4, 26092022, 280920022, 20220923, 4 });

            migrationBuilder.InsertData(
                table: "Rents",
                columns: new[] { "Id", "BookId", "DevolutionDate", "ForecastDate", "RentDate", "UserId" },
                values: new object[] { 4, 2, 26092022, 280920022, 20220923, 3 });

            migrationBuilder.InsertData(
                table: "Rents",
                columns: new[] { "Id", "BookId", "DevolutionDate", "ForecastDate", "RentDate", "UserId" },
                values: new object[] { 2, 3, 26092022, 280920022, 20220923, 2 });

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
