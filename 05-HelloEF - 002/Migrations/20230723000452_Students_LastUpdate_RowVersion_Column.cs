using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelloEF.Migrations
{
    public partial class Students_LastUpdate_RowVersion_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<byte[]>(
                name: "LastUpdate",
                table: "Students",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Students");
        }
    }
}
