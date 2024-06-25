using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoSoUngVien.Migrations
{
    /// <inheritdoc />
    public partial class updateReviewLan1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HuyenId",
                table: "BwXa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuocGiaId",
                table: "BwTinh",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TinhId",
                table: "BwHuyen",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BwXa_HuyenId",
                table: "BwXa",
                column: "HuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_BwTinh_QuocGiaId",
                table: "BwTinh",
                column: "QuocGiaId");

            migrationBuilder.CreateIndex(
                name: "IX_BwHuyen_TinhId",
                table: "BwHuyen",
                column: "TinhId");

            migrationBuilder.AddForeignKey(
                name: "FK_BwHuyen_BwTinh_TinhId",
                table: "BwHuyen",
                column: "TinhId",
                principalTable: "BwTinh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BwTinh_BwQuocGia_QuocGiaId",
                table: "BwTinh",
                column: "QuocGiaId",
                principalTable: "BwQuocGia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BwXa_BwHuyen_HuyenId",
                table: "BwXa",
                column: "HuyenId",
                principalTable: "BwHuyen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BwHuyen_BwTinh_TinhId",
                table: "BwHuyen");

            migrationBuilder.DropForeignKey(
                name: "FK_BwTinh_BwQuocGia_QuocGiaId",
                table: "BwTinh");

            migrationBuilder.DropForeignKey(
                name: "FK_BwXa_BwHuyen_HuyenId",
                table: "BwXa");

            migrationBuilder.DropIndex(
                name: "IX_BwXa_HuyenId",
                table: "BwXa");

            migrationBuilder.DropIndex(
                name: "IX_BwTinh_QuocGiaId",
                table: "BwTinh");

            migrationBuilder.DropIndex(
                name: "IX_BwHuyen_TinhId",
                table: "BwHuyen");

            migrationBuilder.DropColumn(
                name: "HuyenId",
                table: "BwXa");

            migrationBuilder.DropColumn(
                name: "QuocGiaId",
                table: "BwTinh");

            migrationBuilder.DropColumn(
                name: "TinhId",
                table: "BwHuyen");
        }
    }
}
