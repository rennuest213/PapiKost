using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_m_PemilikKost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoHp = table.Column<string>(name: "No_Hp", type: "nvarchar(max)", nullable: false),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_PemilikKost", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_Kosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Harga = table.Column<int>(type: "int", nullable: false),
                    Jenis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Spesifikasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PemilikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_Kosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_tr_Kosts_tb_m_PemilikKost_PemilikID",
                        column: x => x.PemilikID,
                        principalTable: "tb_m_PemilikKost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TanggalLahir = table.Column<string>(name: "Tanggal_Lahir", type: "nvarchar(max)", nullable: false),
                    NoHp = table.Column<string>(name: "No_Hp", type: "nvarchar(max)", nullable: false),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_m_Users_tb_m_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tb_m_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_Users_RoleId",
                table: "tb_m_Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_Kosts_PemilikID",
                table: "tb_tr_Kosts",
                column: "PemilikID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_m_Users");

            migrationBuilder.DropTable(
                name: "tb_tr_Kosts");

            migrationBuilder.DropTable(
                name: "tb_m_Roles");

            migrationBuilder.DropTable(
                name: "tb_m_PemilikKost");
        }
    }
}
