using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FormationVueDotnet.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    CurrentClient = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    DriverLicence = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmergencyContact = table.Column<string>(nullable: true),
                    EmergencyPhoneNumber = table.Column<string>(nullable: true),
                    Entity = table.Column<string>(nullable: true),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    Firstname = table.Column<string>(nullable: true),
                    FunctionDescription = table.Column<string>(nullable: true),
                    FunctionName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Github = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Linkedin = table.Column<string>(nullable: true),
                    Manager = table.Column<string>(nullable: true),
                    NumberOfChild = table.Column<int>(nullable: false),
                    Photo = table.Column<string>(nullable: true),
                    Slack = table.Column<string>(nullable: true),
                    SocialNumber = table.Column<string>(nullable: true),
                    TshirtSize = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    WorkAdress = table.Column<string>(nullable: true),
                    Workcity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactInfoPerso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    City = table.Column<string>(nullable: true),
                    FixedPhone = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    MobilePhone = table.Column<string>(nullable: true),
                    PersonId = table.Column<int>(nullable: false),
                    PostalCode = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfoPerso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactInfoPerso_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactInfoPro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    City = table.Column<string>(nullable: true),
                    FixedPhone = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    MobilePhone = table.Column<string>(nullable: true),
                    PersonId = table.Column<int>(nullable: false),
                    PostalCode = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfoPro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactInfoPro_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Geo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Geo_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    PersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skill_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfoPerso_PersonId",
                table: "ContactInfoPerso",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfoPro_PersonId",
                table: "ContactInfoPro",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Geo_PersonId",
                table: "Geo",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skill_PersonId",
                table: "Skill",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactInfoPerso");

            migrationBuilder.DropTable(
                name: "ContactInfoPro");

            migrationBuilder.DropTable(
                name: "Geo");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
