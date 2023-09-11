using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDevice.API.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionFieldOnSubscriptionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "subscriptions",
                newName: "title");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "subscriptions",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "subscriptions");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "subscriptions",
                newName: "name");
        }
    }
}
