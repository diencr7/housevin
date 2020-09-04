using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseVin.Migrations
{
    public partial class addcloumdirectiontot_houseinfotable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Direction",
                table: "t_HouseInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direction",
                table: "t_HouseInfo");
        }
    }
}
