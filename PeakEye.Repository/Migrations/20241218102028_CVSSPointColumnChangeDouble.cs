using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeakEye.Repository.Migrations
{
    /// <inheritdoc />
    public partial class CVSSPointColumnChangeDouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "CVSSPoint",
                table: "Vulnerabilities",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CVSSPoint",
                table: "Vulnerabilities",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }
    }
}
