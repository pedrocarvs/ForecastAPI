﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherForecast.Infra.Context;

#nullable disable

namespace WeatherForecast.Infra.Migrations
{
    [DbContext(typeof(WeatherForecastDbContext))]
    [Migration("20240219135541_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WeatherForecast.Domain.Entities.ForecastData", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Date")
                        .HasPrecision(6)
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<double>("Temperature")
                        .HasMaxLength(6)
                        .HasColumnType("double");

                    b.Property<DateTimeOffset>("Updated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("ForecastData", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
