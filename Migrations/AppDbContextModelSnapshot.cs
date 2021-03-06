﻿// <auto-generated />
using System;
using LandingPage.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LandingPage.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LandingPage.Models.PostModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<DateTime>("EditedDateTime");

                    b.Property<string>("Tags");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("LandingPage.Models.ProfileModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescriptionBlurb");

                    b.Property<string>("ProfileName");

                    b.HasKey("ID");

                    b.ToTable("ProfileData");
                });
#pragma warning restore 612, 618
        }
    }
}
