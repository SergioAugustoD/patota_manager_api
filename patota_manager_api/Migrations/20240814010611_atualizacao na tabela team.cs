﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace patota_manager_api.Migrations
{
    /// <inheritdoc />
    public partial class atualizacaonatabelateam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_team");

            migrationBuilder.CreateTable(
                name: "tb_team",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    uf = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    address_number = table.Column<int>(type: "integer", nullable: false),
                    skill_level = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_team", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_team_tb_user_created_by",
                        column: x => x.created_by,
                        principalTable: "tb_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_team_created_by",
                table: "tb_team",
                column: "created_by");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_team");

            migrationBuilder.CreateTable(
                name: "tb_team",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    location = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    skill_level = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_team", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_team_tb_user_created_by",
                        column: x => x.created_by,
                        principalTable: "tb_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_team_created_by",
                table: "tb_team",
                column: "created_by");
        }
    }
}
