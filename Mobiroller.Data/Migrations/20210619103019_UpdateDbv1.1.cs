using Microsoft.EntityFrameworkCore.Migrations;

namespace Mobiroller.Data.Migrations
{
    public partial class UpdateDbv11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventsIt",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dc_Orario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dc_Categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dc_Evento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsIt", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EventsTr",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dc_Zaman = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dc_Kategori = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dc_Olay = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsTr", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventsIt");

            migrationBuilder.DropTable(
                name: "EventsTr");
        }
    }
}
