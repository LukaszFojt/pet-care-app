using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetCareApplication.Migrations
{
    /// <inheritdoc />
    public partial class fixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "user",
                table: "ChatMessageRecipients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "user",
                table: "ChatMessageRecipients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "user",
                table: "ChatMessageRecipients");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "user",
                table: "ChatMessageRecipients");
        }
    }
}
