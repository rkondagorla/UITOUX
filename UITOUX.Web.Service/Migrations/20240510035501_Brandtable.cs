using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UITOUX.Web.Service.Migrations
{
    /// <inheritdoc />
    public partial class Brandtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brands",
                columns: table => new
                {
                    BrandId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Code = table.Column<string>(type: "TEXT", nullable: true),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<long>(type: "INTEGER", nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<long>(type: "INTEGER", nullable: true),
                    ModifiedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brands", x => x.BrandId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "brands");
        }
    }
}
