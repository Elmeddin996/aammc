using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace aammc.Migrations
{
    public partial class ProjectAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Sliders",
                newName: "TitleRu");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Sliders",
                newName: "TitleEn");

            migrationBuilder.RenameColumn(
                name: "ButtonText",
                table: "Sliders",
                newName: "TitleAz");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Settings",
                newName: "AddressRu");

            migrationBuilder.AddColumn<string>(
                name: "ButtonTextAz",
                table: "Sliders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ButtonTextEn",
                table: "Sliders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ButtonTextRu",
                table: "Sliders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionAz",
                table: "Sliders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                table: "Sliders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionRu",
                table: "Sliders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressAz",
                table: "Settings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressEn",
                table: "Settings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TitleAz = table.Column<string>(type: "text", nullable: false),
                    TitleEn = table.Column<string>(type: "text", nullable: false),
                    TitleRu = table.Column<string>(type: "text", nullable: false),
                    DescriptionAz = table.Column<string>(type: "text", nullable: false),
                    DescriptionEn = table.Column<string>(type: "text", nullable: false),
                    DescriptionRu = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropColumn(
                name: "ButtonTextAz",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "ButtonTextEn",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "ButtonTextRu",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "DescriptionAz",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "DescriptionRu",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "AddressAz",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AddressEn",
                table: "Settings");

            migrationBuilder.RenameColumn(
                name: "TitleRu",
                table: "Sliders",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "TitleEn",
                table: "Sliders",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "TitleAz",
                table: "Sliders",
                newName: "ButtonText");

            migrationBuilder.RenameColumn(
                name: "AddressRu",
                table: "Settings",
                newName: "Address");
        }
    }
}
