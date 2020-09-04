using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseVin.Migrations
{
    public partial class addcloumDelFlg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DelFlg",
                table: "t_HouseInfo",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DelFlg",
                table: "t_HouseInfo");
        }
    }
}
