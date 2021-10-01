using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HyperAutomation.ControlRoom.Server.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8ad3968e-438d-4a2d-bf47-98bd20cd7f61"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("faf58bbc-d402-42f2-94c0-f811c358892a"), new Guid("ca8be584-3b35-4e68-a590-5ca460c93431") });

            migrationBuilder.DeleteData(
                table: "UserProfile",
                keyColumn: "UserId",
                keyValue: new Guid("ca8be584-3b35-4e68-a590-5ca460c93431"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("faf58bbc-d402-42f2-94c0-f811c358892a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ca8be584-3b35-4e68-a590-5ca460c93431"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "UserProfile",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastLogin",
                table: "UserProfile",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "UserProfile",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Bots",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedOn",
                table: "Bots",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Bots",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "BotFolder",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedOn",
                table: "BotFolder",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "BotFolder",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("74058a2f-6897-47e0-b2d6-8452081ecd44"), "494c8277-a8f0-4344-9cf5-b87045296211", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("08168169-0795-4d45-9ef5-0eb13f1592cb"), "f85a6563-ae7a-49b7-bc76-4e04c38c74ae", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("30e7d1dd-7ac6-4117-807c-20ef2052dda2"), 0, "7cacdc44-d3f2-4b9e-b5ca-389189ebb49b", "Admin@Admin.com", true, false, null, "ADMIN@ADMIN.COM", "MASTERADMIN", "AQAAAAEAACcQAAAAEIJgPC6tk8+HCqO3NYxHiZzfqR00qQHCsFoc65JtWLfe/1NGO5j4Ee+ITImj97V6Zg==", "00000000000", true, "00000000-0000-0000-0000-000000000000", false, "masteradmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("08168169-0795-4d45-9ef5-0eb13f1592cb"), new Guid("30e7d1dd-7ac6-4117-807c-20ef2052dda2") });

            migrationBuilder.InsertData(
                table: "UserProfile",
                columns: new[] { "UserId", "CreatedOn", "Email", "FirstName", "Foto", "IsActive", "IsSuperUser", "LastLogin", "LastName", "ModifiedByUserId", "ModifiedOn", "Password", "UserName" },
                values: new object[] { new Guid("30e7d1dd-7ac6-4117-807c-20ef2052dda2"), null, "Admin@Admin.com", "Master", null, true, true, null, "Admin", null, null, "", "masteradmin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("74058a2f-6897-47e0-b2d6-8452081ecd44"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("08168169-0795-4d45-9ef5-0eb13f1592cb"), new Guid("30e7d1dd-7ac6-4117-807c-20ef2052dda2") });

            migrationBuilder.DeleteData(
                table: "UserProfile",
                keyColumn: "UserId",
                keyValue: new Guid("30e7d1dd-7ac6-4117-807c-20ef2052dda2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("08168169-0795-4d45-9ef5-0eb13f1592cb"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("30e7d1dd-7ac6-4117-807c-20ef2052dda2"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "UserProfile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastLogin",
                table: "UserProfile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "UserProfile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Bots",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedOn",
                table: "Bots",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Bots",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "BotFolder",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedOn",
                table: "BotFolder",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "BotFolder",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("8ad3968e-438d-4a2d-bf47-98bd20cd7f61"), "0c9aae60-b22f-4b96-a467-71596c2e3d5e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("faf58bbc-d402-42f2-94c0-f811c358892a"), "79bdfebf-816b-455f-a163-97fe6418ebad", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("ca8be584-3b35-4e68-a590-5ca460c93431"), 0, "b63295bd-ff0e-4047-a9ae-d33dd424fea3", "Admin@Admin.com", true, false, null, "ADMIN@ADMIN.COM", "MASTERADMIN", "AQAAAAEAACcQAAAAEJ2aU+08AyDzW73jiOsME12GKxaqJqzgGQlRZI1eOMOm0cPNd2ibyg0cH/1lHlzARA==", "00000000000", true, "00000000-0000-0000-0000-000000000000", false, "masteradmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("faf58bbc-d402-42f2-94c0-f811c358892a"), new Guid("ca8be584-3b35-4e68-a590-5ca460c93431") });

            migrationBuilder.InsertData(
                table: "UserProfile",
                columns: new[] { "UserId", "CreatedOn", "Email", "FirstName", "Foto", "IsActive", "IsSuperUser", "LastLogin", "LastName", "ModifiedByUserId", "ModifiedOn", "Password", "UserName" },
                values: new object[] { new Guid("ca8be584-3b35-4e68-a590-5ca460c93431"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin@Admin.com", "Master", null, true, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "masteradmin" });
        }
    }
}
