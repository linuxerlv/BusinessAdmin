using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessAdmin.DataAccess.Migrations.TraData
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TradeData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AllTra = table.Column<int>(type: "INTEGER", nullable: false),
                    SpeTra = table.Column<int>(type: "INTEGER", nullable: false),
                    NorTra = table.Column<int>(type: "INTEGER", nullable: false),
                    UserCount = table.Column<int>(type: "INTEGER", nullable: false),
                    ManagerCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Time = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeData", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TradeData");
        }
    }
}
