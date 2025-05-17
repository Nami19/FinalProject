using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JwtAuthDemo.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Sex = table.Column<char>(type: "character(1)", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    CivilStatus = table.Column<string>(type: "text", nullable: false),
                    Citizenship = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CertificationsLicenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PRCLicense = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OtherCertification = table.Column<string>(type: "text", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificationsLicenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CertificationsLicenses_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Educationalbackground",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ElementarySchool = table.Column<string>(type: "text", nullable: false),
                    ElementaryYearAttended = table.Column<int>(type: "integer", nullable: false),
                    HighSchool = table.Column<string>(type: "text", nullable: false),
                    HighSchoolYearAttended = table.Column<int>(type: "integer", nullable: false),
                    CollegeSchool = table.Column<string>(type: "text", nullable: false),
                    CollegeYearAttended2 = table.Column<int>(type: "integer", nullable: false),
                    DegreeReceived = table.Column<string>(type: "text", nullable: false),
                    SpecialSkills = table.Column<string>(type: "text", nullable: false),
                    Others = table.Column<string>(type: "text", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educationalbackground", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Educationalbackground_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GovernmentInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SSS = table.Column<string>(type: "text", nullable: false),
                    PhilHealth = table.Column<string>(type: "text", nullable: false),
                    PagIbig = table.Column<string>(type: "text", nullable: false),
                    TinID = table.Column<string>(type: "text", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GovernmentInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GovernmentInfo_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PersonalInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Sex = table.Column<char>(type: "character(1)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HiredDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BirthPlace = table.Column<string>(type: "text", nullable: false),
                    EmailAddress = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<int>(type: "integer", nullable: false),
                    CivilStatus = table.Column<string>(type: "text", nullable: false),
                    Religion = table.Column<string>(type: "text", nullable: false),
                    Citizenship = table.Column<string>(type: "text", nullable: false),
                    PresentAddress = table.Column<string>(type: "text", nullable: false),
                    PermanentAddress = table.Column<string>(type: "text", nullable: false),
                    Height = table.Column<string>(type: "text", nullable: false),
                    Weight = table.Column<string>(type: "text", nullable: false),
                    BloodType = table.Column<string>(type: "text", nullable: false),
                    FathersName = table.Column<string>(type: "text", nullable: false),
                    FathersOccupation = table.Column<string>(type: "text", nullable: false),
                    MothersName = table.Column<string>(type: "text", nullable: false),
                    MothersOccupation = table.Column<string>(type: "text", nullable: false),
                    PersonContactedInCaseOfEmergency = table.Column<string>(type: "text", nullable: false),
                    Relationship = table.Column<string>(type: "text", nullable: false),
                    ContactNumber = table.Column<int>(type: "integer", nullable: false),
                    PositionDesired = table.Column<string>(type: "text", nullable: false),
                    DateApplied = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalInformation_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RelevantTrainings = table.Column<string>(type: "text", nullable: false),
                    TrainingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingInfo_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkExperience",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PreviousCompanies = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndtDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkExperience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkExperience_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Employmentstatus = table.Column<string>(type: "text", nullable: false),
                    DateHired = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Position = table.Column<string>(type: "text", nullable: false),
                    Reportorial = table.Column<string>(type: "text", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkInfo_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CertificationsLicenses_EmployeeId",
                table: "CertificationsLicenses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Educationalbackground_EmployeeId",
                table: "Educationalbackground",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_GovernmentInfo_EmployeeId",
                table: "GovernmentInfo",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformation_EmployeeId",
                table: "PersonalInformation",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingInfo_EmployeeId",
                table: "TrainingInfo",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperience_EmployeeId",
                table: "WorkExperience",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkInfo_EmployeeId",
                table: "WorkInfo",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CertificationsLicenses");

            migrationBuilder.DropTable(
                name: "Educationalbackground");

            migrationBuilder.DropTable(
                name: "GovernmentInfo");

            migrationBuilder.DropTable(
                name: "PersonalInformation");

            migrationBuilder.DropTable(
                name: "TrainingInfo");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WorkExperience");

            migrationBuilder.DropTable(
                name: "WorkInfo");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
