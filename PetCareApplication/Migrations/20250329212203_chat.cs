using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetCareApplication.Migrations
{
    /// <inheritdoc />
    public partial class chat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatMessages",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserEntityId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMessages_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalSchema: "user",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChatMessageRecipients",
                schema: "user",
                columns: table => new
                {
                    ChatMessageId = table.Column<int>(type: "int", nullable: false),
                    RecipientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    UserEntityId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessageRecipients", x => new { x.ChatMessageId, x.RecipientId });
                    table.ForeignKey(
                        name: "FK_ChatMessageRecipients_ChatMessages_ChatMessageId",
                        column: x => x.ChatMessageId,
                        principalSchema: "user",
                        principalTable: "ChatMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatMessageRecipients_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalSchema: "user",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessageRecipients_RecipientId",
                schema: "user",
                table: "ChatMessageRecipients",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessageRecipients_UserEntityId",
                schema: "user",
                table: "ChatMessageRecipients",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_SenderId",
                schema: "user",
                table: "ChatMessages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_UserEntityId",
                schema: "user",
                table: "ChatMessages",
                column: "UserEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMessageRecipients",
                schema: "user");

            migrationBuilder.DropTable(
                name: "ChatMessages",
                schema: "user");
        }
    }
}
