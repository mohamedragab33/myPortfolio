using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialCreates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    Stret = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PortfileItems",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    ProjectName = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfileItems", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "owners",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    FullName = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    profile = table.Column<string>(nullable: true),
                    addressid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owners", x => x.id);
                    table.ForeignKey(
                        name: "FK_owners_Address_addressid",
                        column: x => x.addressid,
                        principalTable: "Address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "owners",
                columns: new[] { "id", "Avatar", "FullName", "addressid", "profile" },
                values: new object[] { new Guid("2fe009e0-3f4a-4c14-9098-b5e71c3fccde"), "avatar.jpg", "mohamed ragab ", null, "asp.net core web developer" });

            migrationBuilder.CreateIndex(
                name: "IX_owners_addressid",
                table: "owners",
                column: "addressid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "owners");

            migrationBuilder.DropTable(
                name: "PortfileItems");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
