using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RecipeBookApi.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    stars = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    food_type = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foods_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Age", "name", "stars", "Surname" },
                values: new object[,]
                {
                    { 1, 25, "Sarp", 5, "Arslan" },
                    { 2, 22, "Mike", 5, "Corc" },
                    { 3, 19, "Dummy", 6, "Dumm" }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "AuthorId", "food_type", "Location", "Name" },
                values: new object[,]
                {
                    { 1, 1, 0, null, "Menemen" },
                    { 2, 1, 0, null, "Tost" },
                    { 3, 1, 0, null, "Kebap" },
                    { 4, 2, 0, null, "Dumm" },
                    { 5, 2, 0, null, "DumHamburger" },
                    { 6, 3, 0, null, "Kebap" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foods_AuthorId",
                table: "Foods",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
