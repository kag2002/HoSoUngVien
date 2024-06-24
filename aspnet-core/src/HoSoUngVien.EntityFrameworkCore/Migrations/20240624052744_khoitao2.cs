using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoSoUngVien.Migrations
{
    /// <inheritdoc />
    public partial class khoitao2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BwUngVien_BwXa_XaId",
                table: "BwUngVien");

            migrationBuilder.DropIndex(
                name: "IX_BwUngVien_XaId",
                table: "BwUngVien");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BwUngVien_XaId",
                table: "BwUngVien",
                column: "XaId");

            migrationBuilder.AddForeignKey(
                name: "FK_BwUngVien_BwXa_XaId",
                table: "BwUngVien",
                column: "XaId",
                principalTable: "BwXa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
