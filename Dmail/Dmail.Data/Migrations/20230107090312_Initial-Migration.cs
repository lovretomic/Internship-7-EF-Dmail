using System;
using System.Collections.Generic;
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
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SenderId = table.Column<int>(type: "integer", nullable: false),
                    Receivers = table.Column<List<int>>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    SentOn = table.Column<string>(type: "text", nullable: false),
                    SenderId = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
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
                name: "UserEvents",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEvents", x => new { x.UserId, x.EventId });
                    table.ForeignKey(
                        name: "FK_UserEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEvents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMessages",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    MessageId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMessages", x => new { x.UserId, x.MessageId });
                    table.ForeignKey(
                        name: "FK_UserMessages_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMessages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Content", "SenderId", "SentOn", "Title" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam auctor lorem at auctor cursus. Nunc gravida tincidunt mauris, non laoreet magna gravida vitae. Nullam tempor consequat sem, id iaculis ante tristique a. Pellentesque fringilla mattis molestie. Nunc eu ante a urna feugiat congue. Donec volutpat nisi eu libero commodo, a.", 3, "2023-01-06", "Mail1" },
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam auctor lorem at auctor cursus. Nunc gravida tincidunt mauris, non laoreet magna gravida vitae. Nullam tempor consequat sem, id iaculis ante tristique a. Pellentesque fringilla mattis molestie. Nunc eu ante a urna feugiat congue. Donec volutpat nisi eu libero commodo, a.", 3, "2023-01-05", "Mail2" },
                    { 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam auctor lorem at auctor cursus. Nunc gravida tincidunt mauris, non laoreet magna gravida vitae. Nullam tempor consequat sem, id iaculis ante tristique a. Pellentesque fringilla mattis molestie. Nunc eu ante a urna feugiat congue. Donec volutpat nisi eu libero commodo, a.", 3, "2023-01-04", "Mail3" }
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
                table: "UserMessages",
                columns: new[] { "MessageId", "UserId", "Status" },
                values: new object[,]
                {
                    { 2, 11, 0 },
                    { 1, 14, 0 },
                    { 1, 16, 0 },
                    { 2, 16, 0 },
                    { 3, 16, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserEvents_EventId",
                table: "UserEvents",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMessages_MessageId",
                table: "UserMessages",
                column: "MessageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEvents");

            migrationBuilder.DropTable(
                name: "UserMessages");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
