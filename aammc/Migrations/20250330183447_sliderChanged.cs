using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aammc.Migrations
{
    public partial class sliderChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image2",
                table: "Sliders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image3",
                table: "Sliders",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image2",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Image3",
                table: "Sliders");
        }
    }
}
