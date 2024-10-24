using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtendimentoInfra.Migrations
{
    /// <inheritdoc />
    public partial class AjusteRelacionamentoUsersGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserOwnerId",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Group");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerUserId",
                table: "Group",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "GroupUser",
                columns: table => new
                {
                    ParticipatingGroupsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParticipatingUsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUser", x => new { x.ParticipatingGroupsId, x.ParticipatingUsersId });
                    table.ForeignKey(
                        name: "FK_GroupUser_Group_ParticipatingGroupsId",
                        column: x => x.ParticipatingGroupsId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupUser_Users_ParticipatingUsersId",
                        column: x => x.ParticipatingUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Group_OwnerUserId",
                table: "Group",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUser_ParticipatingUsersId",
                table: "GroupUser",
                column: "ParticipatingUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Users_OwnerUserId",
                table: "Group",
                column: "OwnerUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_Users_OwnerUserId",
                table: "Group");

            migrationBuilder.DropTable(
                name: "GroupUser");

            migrationBuilder.DropIndex(
                name: "IX_Group_OwnerUserId",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "Group");

            migrationBuilder.AddColumn<Guid>(
                name: "UserOwnerId",
                table: "Group",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "Group",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
