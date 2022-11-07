using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NET104_Project.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sanpham",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Trangthai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sanpham", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SanphamChitiet",
                columns: table => new
                {
                    IdChitietSp = table.Column<Guid>(nullable: false),
                    IdSp = table.Column<Guid>(nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Gianhap = table.Column<int>(type: "int", nullable: false),
                    Giaban = table.Column<int>(type: "int", nullable: false),
                    Soluong = table.Column<int>(type: "int", nullable: false),
                    Trangthai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanphamChitiet", x => x.IdChitietSp);
                    table.ForeignKey(
                        name: "FK_SanphamChitiet_Sanpham_IdSp",
                        column: x => x.IdSp,
                        principalTable: "Sanpham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SanphamChitiet_IdSp",
                table: "SanphamChitiet",
                column: "IdSp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SanphamChitiet");

            migrationBuilder.DropTable(
                name: "Sanpham");
        }
    }
}
