using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseVin.Migrations
{
    public partial class AddCloumThumbnail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Thumbnail",
                table: "t_HouseInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Thumbnail",
                table: "t_HouseInfo");
        }
    }
}
