using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Dmail.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    SentOn = table.Column<string>(type: "text", nullable: false),
                    SenderId = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Attendance = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    IsSpam = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserItems", x => new { x.UserId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_UserItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Content", "SenderId", "SentOn", "StartDate", "Title", "Type" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam auctor lorem at auctor cursus. Nunc gravida tincidunt mauris, non laoreet magna gravida vitae. Nullam tempor consequat sem, id iaculis ante tristique a. Pellentesque fringilla mattis molestie. Nunc eu ante a urna feugiat congue. Donec volutpat nisi eu libero commodo, a.", 3, "2023-01-06", "", "Mail1", 0 },
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam auctor lorem at auctor cursus. Nunc gravida tincidunt mauris, non laoreet magna gravida vitae. Nullam tempor consequat sem, id iaculis ante tristique a. Pellentesque fringilla mattis molestie. Nunc eu ante a urna feugiat congue. Donec volutpat nisi eu libero commodo, a.", 3, "2023-01-05", "", "Mail2", 0 },
                    { 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam auctor lorem at auctor cursus. Nunc gravida tincidunt mauris, non laoreet magna gravida vitae. Nullam tempor consequat sem, id iaculis ante tristique a. Pellentesque fringilla mattis molestie. Nunc eu ante a urna feugiat congue. Donec volutpat nisi eu libero commodo, a.", 3, "2023-01-04", "", "Mail3", 0 },
                    { 4, "", 7, "2022-12-06", "2022-12-07", "Event1", 1 },
                    { 5, "", 4, "2022-12-10", "2022-12-10", "Event2", 1 },
                    { 6, "", 16, "2022-12-17", "2022-12-16", "Event3", 1 },
                    { 7, "", 2, "2022-12-29", "2022-12-20", "Event4", 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, "jadrankalovric@gmail.com", "Jadranka", "Lovrić", "QJpzGc94Vf7P" },
                    { 2, "mate.jerkovic@gmail.com", "Mate", "Jerković", "4K3fgnoj7T3V" },
                    { 3, "hercegdragoslav@gmail.com", "Dragoslav", "Herceg", "QsoCrT4CqErv" },
                    { 4, "vukojaranka90@hotmail.com", "Ranka", "Vukoja", "y45LRkBQjtmg" },
                    { 5, "helenaknez@gmail.com", "Helena", "Knežević", "P5LWdm9sDPnc" },
                    { 6, "stipel@gmail.com", "Stjepan", "Lučić", "bBQ3mEVXFEHc" },
                    { 7, "visnja.pavlovic@gmail.com", "Višnja", "Pavlović", "8u8sBshThMnK" },
                    { 8, "alenkosar1@gmail.com", "Alen", "Košar", "G2TJfh1BgjJo" },
                    { 9, "nikolic.p@gmail.com", "Pero", "Nikolić", "0nUda4jTo7Ar" },
                    { 10, "jankojuric99@yahoo.com", "Janko", "Jurić", "vugpkNAzkp6G" },
                    { 11, "domagoj.jerko@gmail.com", "Domagoj", "Jerković", "b3VigXxiQJkR" },
                    { 12, "lucicantonela@gmail.com", "Antonela", "Lučić", "WZv4zYpAVszQ" },
                    { 13, "adam.ivanovic2@gmail.com", "Adam", "Ivanović", "BvHVg4EyWja6" },
                    { 14, "brunopavicic@gmail.com", "Bruno", "Pavičić", "3jiW5m92eFsb" },
                    { 15, "perko.anja09@gmail.com", "Anja", "Perko", "qkipaEkfPi2P" },
                    { 16, "tomiclovre05@gmail.com", "Lovre", "Tomić", "pass123" }
                });

            migrationBuilder.InsertData(
                table: "UserItems",
                columns: new[] { "ItemId", "UserId", "Attendance", "IsSpam", "Status" },
                values: new object[,]
                {
                    { 7, 1, 0, false, 0 },
                    { 5, 2, 0, false, 0 },
                    { 4, 7, 0, false, 0 },
                    { 2, 11, 0, false, 0 },
                    { 1, 14, 0, false, 0 },
                    { 6, 14, 0, false, 0 },
                    { 1, 16, 0, false, 0 },
                    { 2, 16, 0, false, 0 },
                    { 3, 16, 0, false, 0 },
                    { 5, 16, 0, false, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserItems_ItemId",
                table: "UserItems",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserItems");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
