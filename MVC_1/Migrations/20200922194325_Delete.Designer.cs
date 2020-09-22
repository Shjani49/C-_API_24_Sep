﻿// <auto-generated />
using MVC_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVC_1.Migrations
{
    [DbContext(typeof(PersonContext))]
    [Migration("20200922194325_Delete")]
    partial class Delete
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MVC_1.Models.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int(10)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.HasKey("ID");

                    b.ToTable("person");

                    b.HasData(
                        new
                        {
                            ID = -1,
                            FirstName = "John",
                            LastName = "Doe"
                        },
                        new
                        {
                            ID = -2,
                            FirstName = "Jane",
                            LastName = "Doe"
                        },
                        new
                        {
                            ID = -3,
                            FirstName = "Todd",
                            LastName = "Smith"
                        },
                        new
                        {
                            ID = -4,
                            FirstName = "Sue",
                            LastName = "Smith"
                        },
                        new
                        {
                            ID = -5,
                            FirstName = "Joe",
                            LastName = "Smithserson"
                        });
                });

            modelBuilder.Entity("MVC_1.Models.PhoneNumber", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int(10)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("char(12)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.Property<int>("PersonID")
                        .HasColumnName("PersonID")
                        .HasColumnType("int(10)");

                    b.HasKey("ID");

                    b.HasIndex("PersonID")
                        .HasName("FK_PhoneNumber_Person");

                    b.ToTable("phonenumber");

                    b.HasData(
                        new
                        {
                            ID = -1,
                            Number = "800-234-4567",
                            PersonID = -1
                        },
                        new
                        {
                            ID = -2,
                            Number = "800-234-4567",
                            PersonID = -2
                        },
                        new
                        {
                            ID = -3,
                            Number = "800-345-5678",
                            PersonID = -2
                        },
                        new
                        {
                            ID = -4,
                            Number = "800-456-6789",
                            PersonID = -3
                        },
                        new
                        {
                            ID = -5,
                            Number = "800-987-7654",
                            PersonID = -4
                        },
                        new
                        {
                            ID = -6,
                            Number = "800-876-6543",
                            PersonID = -5
                        },
                        new
                        {
                            ID = -7,
                            Number = "800-765-5432",
                            PersonID = -5
                        });
                });

            modelBuilder.Entity("MVC_1.Models.PhoneNumber", b =>
                {
                    b.HasOne("MVC_1.Models.Person", "Person")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("PersonID")
                        .HasConstraintName("FK_PhoneNumber_Person")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}