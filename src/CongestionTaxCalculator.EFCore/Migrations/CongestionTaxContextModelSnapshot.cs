﻿// <auto-generated />
using System;
using CongestionTaxCalculator.EFCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CongestionTaxCalculator.EFCore.Migrations
{
    [DbContext(typeof(CongestionTaxContext))]
    partial class CongestionTaxContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Persistence.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Persistence.ExemptVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("TariffDefinitionId")
                        .HasColumnType("int");

                    b.Property<string>("VehicleType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("TariffDefinitionId");

                    b.HasIndex("VehicleType");

                    b.ToTable("ExemptVehicles");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Persistence.PublicHoliday", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateHoliday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int>("TariffSettingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TariffSettingId");

                    b.ToTable("PublicHolidays");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Persistence.TariffCost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<TimeSpan>("FromTime")
                        .HasColumnType("time");

                    b.Property<int>("TariffDefinitionId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("ToTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("TariffDefinitionId");

                    b.ToTable("TariffCosts");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Persistence.TariffDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("StartTariffYear")
                        .HasColumnType("int");

                    b.Property<int>("TariffNO")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId", "StartTariffYear", "TariffNO")
                        .IsUnique();

                    b.ToTable("TariffDefinitions");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Persistence.TariffSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("MaxTaxAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("NumberTaxFreeDaysBeforeHoliday")
                        .HasColumnType("int");

                    b.Property<int>("SingleCharegeInterval")
                        .HasColumnType("int");

                    b.Property<int>("TariffDefinitionId")
                        .HasColumnType("int");

                    b.Property<int>("TaxFreeMonthCalender")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TariffDefinitionId")
                        .IsUnique();

                    b.ToTable("TariffSettings");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Persistence.WorkingDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsWeekend")
                        .HasColumnType("bit");

                    b.Property<int>("day")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WorkingDays");
                });

            modelBuilder.Entity("TariffSettingWorkingDay", b =>
                {
                    b.Property<int>("TariffSettingsId")
                        .HasColumnType("int");

                    b.Property<int>("WorkingDaysId")
                        .HasColumnType("int");

                    b.HasKey("TariffSettingsId", "WorkingDaysId");

                    b.HasIndex("WorkingDaysId");

                    b.ToTable("TariffSettingWorkingDay");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Persistence.ExemptVehicle", b =>
                {
                    b.HasOne("CongestionTaxCalculator.Domain.Persistence.TariffDefinition", "TariffDefinition")
                        .WithMany("ExemptVehicles")
                        .HasForeignKey("TariffDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TariffDefinition");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Persistence.PublicHoliday", b =>
                {
                    b.HasOne("CongestionTaxCalculator.Domain.Persistence.TariffSetting", "TariffSetting")
                        .WithMany("PublicHolidays")
                        .HasForeignKey("TariffSettingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TariffSetting");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Persistence.TariffCost", b =>
                {
                    b.HasOne("CongestionTaxCalculator.Domain.Persistence.TariffDefinition", "TariffDefinition")
                        .WithMany("TariffCosts")
                        .HasForeignKey("TariffDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TariffDefinition");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Persistence.TariffDefinition", b =>
                {
                    b.HasOne("CongestionTaxCalculator.Domain.Persistence.City", "City")
                        .WithMany("TariffDefinitions")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Persistence.TariffSetting", b =>
                {
                    b.HasOne("CongestionTaxCalculator.Domain.Persistence.TariffDefinition", "TariffDefinition")
                        .WithOne("TariffSetting")
                        .HasForeignKey("CongestionTaxCalculator.Domain.Persistence.TariffSetting", "TariffDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TariffDefinition");
                });

            modelBuilder.Entity("TariffSettingWorkingDay", b =>
                {
                    b.HasOne("CongestionTaxCalculator.Domain.Persistence.TariffSetting", null)
                        .WithMany()
                        .HasForeignKey("TariffSettingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CongestionTaxCalculator.Domain.Persistence.WorkingDay", null)
                        .WithMany()
                        .HasForeignKey("WorkingDaysId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Persistence.City", b =>
                {
                    b.Navigation("TariffDefinitions");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Persistence.TariffDefinition", b =>
                {
                    b.Navigation("ExemptVehicles");

                    b.Navigation("TariffCosts");

                    b.Navigation("TariffSetting");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Domain.Persistence.TariffSetting", b =>
                {
                    b.Navigation("PublicHolidays");
                });
#pragma warning restore 612, 618
        }
    }
}
