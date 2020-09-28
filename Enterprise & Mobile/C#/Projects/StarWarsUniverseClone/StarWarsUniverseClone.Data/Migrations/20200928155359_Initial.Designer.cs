﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StarWarsUniverseClone.Data;

namespace StarWarsUniverseClone.Data.Migrations
{
    [DbContext(typeof(StarWarsContext))]
    [Migration("20200928155359_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StarWarsUniverseClone.Domain.Movie", b =>
                {
                    b.Property<string>("Uri")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Director")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Edited")
                        .HasColumnType("datetime2");

                    b.Property<int>("EpisodeId")
                        .HasColumnType("int");

                    b.Property<string>("OpeningCrawl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Producer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Uri");

                    b.ToTable("Movie");
                });
#pragma warning restore 612, 618
        }
    }
}
