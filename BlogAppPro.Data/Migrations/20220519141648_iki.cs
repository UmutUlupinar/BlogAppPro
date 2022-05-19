using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogAppPro.Data.Migrations
{
    public partial class iki : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Content = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ViewsCount = table.Column<int>(type: "int", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    SeoAuthor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeoTags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeoDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticleID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleID",
                        column: x => x.ArticleID,
                        principalTable: "Articles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[] { 1, "Admin", new DateTime(2022, 5, 19, 17, 16, 47, 918, DateTimeKind.Local).AddTicks(3564), null, true, false, "Admin", new DateTime(2022, 5, 19, 17, 16, 47, 918, DateTimeKind.Local).AddTicks(3565), "C#", "C# is a general-purpose, object-oriented programming language developed" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[] { 2, "Admin", new DateTime(2022, 5, 19, 17, 16, 47, 918, DateTimeKind.Local).AddTicks(3567), null, true, false, "Admin", new DateTime(2022, 5, 19, 17, 16, 47, 918, DateTimeKind.Local).AddTicks(3567), "Java", "Java is a general-purpose, object-oriented programming language developed" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[] { 1, "Admin", new DateTime(2022, 5, 19, 17, 16, 47, 918, DateTimeKind.Local).AddTicks(3236), null, true, false, "Admin", new DateTime(2022, 5, 19, 17, 16, 47, 918, DateTimeKind.Local).AddTicks(3237), "Admin", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "CreatedByName", "CreatedDate", "Description", "Email", "FirstName", "IsActive", "IsDeleted", "LastName", "ModifiedByName", "ModifiedDate", "Note", "PasswordHash", "ProfileImage", "RoleID", "UserName" },
                values: new object[] { 1, "Admin", new DateTime(2022, 5, 19, 17, 16, 47, 918, DateTimeKind.Local).AddTicks(2847), null, null, null, true, false, null, "Admin", new DateTime(2022, 5, 19, 17, 16, 47, 918, DateTimeKind.Local).AddTicks(2848), null, new byte[] { 50, 48, 50, 99, 98, 57, 54, 50, 97, 99, 53, 57, 48, 55, 53, 98, 57, 54, 52, 98, 48, 55, 49, 53, 50, 100, 50, 51, 52, 98, 55, 48 }, null, 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ID", "CategoryID", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserID", "ViewsCount" },
                values: new object[] { 1, 1, 0, "c# guzel bir dil", "Admin", new DateTime(2022, 5, 19, 17, 16, 47, 918, DateTimeKind.Local).AddTicks(931), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "Admin", new DateTime(2022, 5, 19, 17, 16, 47, 918, DateTimeKind.Local).AddTicks(939), "sss", null, null, null, null, null, 1, 0 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ID", "CategoryID", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserID", "ViewsCount" },
                values: new object[] { 2, 2, 0, "java guzel diil", "Admin", new DateTime(2022, 5, 19, 17, 16, 47, 918, DateTimeKind.Local).AddTicks(943), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "Admin", new DateTime(2022, 5, 19, 17, 16, 47, 918, DateTimeKind.Local).AddTicks(944), "sss", null, null, null, null, null, 1, 0 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "ID", "ArticleID", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "Text" },
                values: new object[] { 1, 1, "Admin", new DateTime(2022, 5, 19, 17, 16, 47, 918, DateTimeKind.Local).AddTicks(1837), true, false, "Admin", new DateTime(2022, 5, 19, 17, 16, 47, 918, DateTimeKind.Local).AddTicks(1839), "C# is a general-purpose, object-oriented programming language developed", null });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "ID", "ArticleID", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "Text" },
                values: new object[] { 2, 2, "Admin", new DateTime(2022, 5, 19, 17, 16, 47, 918, DateTimeKind.Local).AddTicks(1842), true, false, "Admin", new DateTime(2022, 5, 19, 17, 16, 47, 918, DateTimeKind.Local).AddTicks(1842), "C# is a general-purpose, object-oriented programming language developed", null });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryID",
                table: "Articles",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserID",
                table: "Articles",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleID",
                table: "Comments",
                column: "ArticleID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
