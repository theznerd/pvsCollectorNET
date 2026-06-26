using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pvsCollector.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inverters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WrittenAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    freqHz = table.Column<float>(type: "real", nullable: false),
                    i3phsumA = table.Column<float>(type: "real", nullable: false),
                    iMppt1A = table.Column<float>(type: "real", nullable: false),
                    ltea3phsum = table.Column<float>(type: "real", nullable: false),
                    msmtEps = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    p3phsumKw = table.Column<float>(type: "real", nullable: false),
                    pMppt1Kw = table.Column<float>(type: "real", nullable: false),
                    prodMdlNm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sn = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    tHtsnkDegc = table.Column<int>(type: "int", nullable: false),
                    vMppt1V = table.Column<float>(type: "real", nullable: false),
                    vln3phavgV = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inverters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WrittenAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ctSclFctr = table.Column<int>(type: "int", nullable: false),
                    freqHz = table.Column<float>(type: "real", nullable: false),
                    i1A = table.Column<float>(type: "real", nullable: false),
                    i2A = table.Column<float>(type: "real", nullable: false),
                    msmtEps = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    negLtea3phsumKwh = table.Column<float>(type: "real", nullable: false),
                    netLtea3phsumKwh = table.Column<float>(type: "real", nullable: false),
                    p1Kw = table.Column<float>(type: "real", nullable: false),
                    p2Kw = table.Column<float>(type: "real", nullable: false),
                    p3phsumKw = table.Column<float>(type: "real", nullable: false),
                    posLtea3phsumKwh = table.Column<float>(type: "real", nullable: false),
                    prodMdlNm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    q3phsumKvar = table.Column<float>(type: "real", nullable: false),
                    s3phsumKva = table.Column<float>(type: "real", nullable: false),
                    sn = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    totPfRto = table.Column<float>(type: "real", nullable: false),
                    v12V = table.Column<float>(type: "real", nullable: false),
                    v1nV = table.Column<float>(type: "real", nullable: false),
                    v2nV = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meters", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inverters_sn",
                table: "Inverters",
                column: "sn");

            migrationBuilder.CreateIndex(
                name: "IX_Meters_sn",
                table: "Meters",
                column: "sn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inverters");

            migrationBuilder.DropTable(
                name: "Meters");
        }
    }
}
