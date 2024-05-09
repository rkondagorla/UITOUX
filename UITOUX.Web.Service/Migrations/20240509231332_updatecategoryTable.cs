using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UITOUX.Web.Service.Migrations
{
    /// <inheritdoc />
    public partial class updatecategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "categories",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "bannerItems",
                columns: table => new
                {
                    BannerItemId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BannerId = table.Column<long>(type: "INTEGER", nullable: true),
                    CategoryId = table.Column<long>(type: "INTEGER", nullable: true),
                    URL = table.Column<string>(type: "TEXT", nullable: true),
                    Code = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<long>(type: "INTEGER", nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<long>(type: "INTEGER", nullable: true),
                    ModifiedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bannerItems", x => x.BannerItemId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bannerItems");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "categories");
        }
    }
}
