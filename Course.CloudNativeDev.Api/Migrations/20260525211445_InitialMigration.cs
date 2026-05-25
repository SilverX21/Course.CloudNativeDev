using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Course.CloudNativeDev.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReferalSources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferalSources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attendee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LAstNAme = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ReferalSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendee_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendee_JobRoles_JobRoleId",
                        column: x => x.JobRoleId,
                        principalTable: "JobRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendee_ReferalSources_ReferalSourceId",
                        column: x => x.ReferalSourceId,
                        principalTable: "ReferalSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("51ba96aa-167e-4cff-bca4-0c68d1555086"), "Female" },
                    { new Guid("e51f98bb-d9ee-4496-b195-fb6891046f7d"), "Male" }
                });

            migrationBuilder.InsertData(
                table: "JobRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("51ba96aa-167e-4cff-bca4-0c68f1555034"), "Sales" },
                    { new Guid("51ba96aa-167e-4cff-bca4-0c68f1555086"), "Supervisor" },
                    { new Guid("51ba96aa-167e-4cff-bca4-0c68f1655034"), "Operations" },
                    { new Guid("e51f98bb-d9ee-4496-b145-fb6891046f7d"), "Manager" }
                });

            migrationBuilder.InsertData(
                table: "ReferalSources",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("51ba96aa-167e-4cff-bca4-0c68f1665034"), "Newspaper Article" },
                    { new Guid("51ba96aa-167e-4cff-bca4-0c68f4655034"), "Other" },
                    { new Guid("51ba96aa-167e-4cff-bcb4-0c68f1555086"), "Television" },
                    { new Guid("e51f98bb-d9ee-5496-b145-fb6891046f7d"), "Internet Advertisement" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendee_GenderId",
                table: "Attendee",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendee_JobRoleId",
                table: "Attendee",
                column: "JobRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendee_ReferalSourceId",
                table: "Attendee",
                column: "ReferalSourceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendee");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "JobRoles");

            migrationBuilder.DropTable(
                name: "ReferalSources");
        }
    }
}
