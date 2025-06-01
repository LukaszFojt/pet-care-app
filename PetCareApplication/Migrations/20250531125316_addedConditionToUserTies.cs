using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetCareApplication.Migrations
{
    /// <inheritdoc />
    public partial class addedConditionToUserTies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConditionEntityUserEntity",
                schema: "user");

            migrationBuilder.AddColumn<int>(
                name: "OrderStatus",
                schema: "user",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserEntityId",
                schema: "user",
                table: "Conditions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderId",
                schema: "user",
                table: "ChatMessageRecipients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ConditionToUserTies",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConditionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionToUserTies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conditions_UserEntityId",
                schema: "user",
                table: "Conditions",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conditions_Users_UserEntityId",
                schema: "user",
                table: "Conditions",
                column: "UserEntityId",
                principalSchema: "user",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conditions_Users_UserEntityId",
                schema: "user",
                table: "Conditions");

            migrationBuilder.DropTable(
                name: "ConditionToUserTies",
                schema: "user");

            migrationBuilder.DropIndex(
                name: "IX_Conditions_UserEntityId",
                schema: "user",
                table: "Conditions");

            migrationBuilder.DropColumn(
                name: "OrderStatus",
                schema: "user",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                schema: "user",
                table: "Conditions");

            migrationBuilder.DropColumn(
                name: "SenderId",
                schema: "user",
                table: "ChatMessageRecipients");

            migrationBuilder.CreateTable(
                name: "ConditionEntityUserEntity",
                schema: "user",
                columns: table => new
                {
                    ConditionsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionEntityUserEntity", x => new { x.ConditionsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ConditionEntityUserEntity_Conditions_ConditionsId",
                        column: x => x.ConditionsId,
                        principalSchema: "user",
                        principalTable: "Conditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConditionEntityUserEntity_Users_UsersId",
                        column: x => x.UsersId,
                        principalSchema: "user",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConditionEntityUserEntity_UsersId",
                schema: "user",
                table: "ConditionEntityUserEntity",
                column: "UsersId");
        }
    }
}
