using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CongestionTaxCalculator.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    day = table.Column<int>(type: "int", nullable: false),
                    IsWeekend = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingDays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TariffDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TariffNO = table.Column<int>(type: "int", nullable: false),
                    StartTariffYear = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TariffDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TariffDefinitions_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExemptVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TariffDefinitionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExemptVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExemptVehicles_TariffDefinitions_TariffDefinitionId",
                        column: x => x.TariffDefinitionId,
                        principalTable: "TariffDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TariffCosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ToTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TariffDefinitionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TariffCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TariffCosts_TariffDefinitions_TariffDefinitionId",
                        column: x => x.TariffDefinitionId,
                        principalTable: "TariffDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TariffSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberTaxFreeDaysBeforeHoliday = table.Column<int>(type: "int", nullable: false),
                    MaxTaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxFreeMonthCalender = table.Column<int>(type: "int", nullable: false),
                    SingleCharegeInterval = table.Column<int>(type: "int", nullable: false),
                    TariffDefinitionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TariffSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TariffSettings_TariffDefinitions_TariffDefinitionId",
                        column: x => x.TariffDefinitionId,
                        principalTable: "TariffDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicHolidays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateHoliday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    TariffSettingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicHolidays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicHolidays_TariffSettings_TariffSettingId",
                        column: x => x.TariffSettingId,
                        principalTable: "TariffSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TariffSettingWorkingDay",
                columns: table => new
                {
                    TariffSettingsId = table.Column<int>(type: "int", nullable: false),
                    WorkingDaysId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TariffSettingWorkingDay", x => new { x.TariffSettingsId, x.WorkingDaysId });
                    table.ForeignKey(
                        name: "FK_TariffSettingWorkingDay_TariffSettings_TariffSettingsId",
                        column: x => x.TariffSettingsId,
                        principalTable: "TariffSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TariffSettingWorkingDay_WorkingDays_WorkingDaysId",
                        column: x => x.WorkingDaysId,
                        principalTable: "WorkingDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name",
                table: "Cities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExemptVehicles_TariffDefinitionId",
                table: "ExemptVehicles",
                column: "TariffDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExemptVehicles_VehicleType",
                table: "ExemptVehicles",
                column: "VehicleType");

            migrationBuilder.CreateIndex(
                name: "IX_PublicHolidays_TariffSettingId",
                table: "PublicHolidays",
                column: "TariffSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_TariffCosts_TariffDefinitionId",
                table: "TariffCosts",
                column: "TariffDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_TariffDefinitions_CityId_StartTariffYear_TariffNO",
                table: "TariffDefinitions",
                columns: new[] { "CityId", "StartTariffYear", "TariffNO" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TariffSettings_TariffDefinitionId",
                table: "TariffSettings",
                column: "TariffDefinitionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TariffSettingWorkingDay_WorkingDaysId",
                table: "TariffSettingWorkingDay",
                column: "WorkingDaysId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExemptVehicles");

            migrationBuilder.DropTable(
                name: "PublicHolidays");

            migrationBuilder.DropTable(
                name: "TariffCosts");

            migrationBuilder.DropTable(
                name: "TariffSettingWorkingDay");

            migrationBuilder.DropTable(
                name: "TariffSettings");

            migrationBuilder.DropTable(
                name: "WorkingDays");

            migrationBuilder.DropTable(
                name: "TariffDefinitions");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
