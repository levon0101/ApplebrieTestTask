﻿// <auto-generated />
using ApplebrieTestTask.WebApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApplebrieTestTask.WebApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApplebrieTestTask.WebApi.Entitities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Programmers"
                        },
                        new
                        {
                            Id = 2,
                            Name = "TeamLiders"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Designers"
                        },
                        new
                        {
                            Id = 4,
                            Name = "HRs"
                        });
                });

            modelBuilder.Entity("ApplebrieTestTask.WebApi.Entitities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            FirstName = "Levon",
                            LastName = "Mardanyan"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            FirstName = "Smbat",
                            LastName = "Jamalyan"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            FirstName = "Tigran",
                            LastName = "Mnatsakanyan"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            FirstName = "Other",
                            LastName = "Lead"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 4,
                            FirstName = "Kristina",
                            LastName = "Khachatryan"
                        });
                });

            modelBuilder.Entity("ApplebrieTestTask.WebApi.Entitities.User", b =>
                {
                    b.HasOne("ApplebrieTestTask.WebApi.Entitities.Category", "Category")
                        .WithMany("Users")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
