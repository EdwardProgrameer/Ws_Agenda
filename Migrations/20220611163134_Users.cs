using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ws_Agenda.Migrations
{
    public partial class Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_users",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Email = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    User_Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_users", x => x.User_Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_user_Registred",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    User_LastName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    User_BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    User_Phone = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    User_photo = table.Column<byte[]>(type: "varbinary", unicode: false, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_user_Registred", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_user_Registred_tb_users_UserId",
                        column: x => x.UserId,
                        principalTable: "tb_users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_user_Registred_UserId",
                table: "tb_user_Registred",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_user_Registred");

            migrationBuilder.DropTable(
                name: "tb_users");
        }
    }
}
