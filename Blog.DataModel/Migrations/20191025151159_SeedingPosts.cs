using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.DataModel.Migrations
{
    public partial class SeedingPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "BlogPosts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "BlogPosts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "BlogPosts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "ID", "Auther", "Body", "CreationDate", "ImageUrl", "Subtitle", "Title" },
                values: new object[,]
                {
                    { 1, "Auther1", "Post Body1", new DateTime(2019, 10, 25, 17, 11, 58, 521, DateTimeKind.Local).AddTicks(3681), "Image1", "Subtitle1", "Title1" },
                    { 2, "Auther2", "Post Body2", new DateTime(2019, 10, 25, 17, 11, 58, 524, DateTimeKind.Local).AddTicks(273), "Image2", "Subtitle2", "Title2" },
                    { 3, "Auther3", "Post Body3", new DateTime(2019, 10, 25, 17, 11, 58, 524, DateTimeKind.Local).AddTicks(290), "Image3", "Subtitle3", "Title3" },
                    { 4, "Auther4", "Post Body4", new DateTime(2019, 10, 25, 17, 11, 58, 524, DateTimeKind.Local).AddTicks(294), "Image4", "Subtitle4", "Title4" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "BlogPosts",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "BlogPosts",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "BlogPosts",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
