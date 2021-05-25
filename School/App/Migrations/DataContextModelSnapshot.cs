﻿// <auto-generated />
using App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace App.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("App.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("CourseGrade")
                        .HasColumnType("REAL");

                    b.Property<string>("CourseName")
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Grades");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseGrade = 90.0,
                            CourseName = "English I",
                            StudentId = 1
                        },
                        new
                        {
                            Id = 2,
                            CourseGrade = 70.0,
                            CourseName = "Calculus II",
                            StudentId = 1
                        },
                        new
                        {
                            Id = 3,
                            CourseGrade = 50.0,
                            CourseName = "Theater Appreciation",
                            StudentId = 2
                        },
                        new
                        {
                            Id = 4,
                            CourseGrade = 85.0,
                            CourseName = "Dynamic Programming",
                            StudentId = 2
                        },
                        new
                        {
                            Id = 5,
                            CourseGrade = 15.0,
                            CourseName = "Data Structures",
                            StudentId = 2
                        },
                        new
                        {
                            Id = 6,
                            CourseGrade = 97.0,
                            CourseName = "Senior Design I",
                            StudentId = 3
                        },
                        new
                        {
                            Id = 7,
                            CourseGrade = 75.0,
                            CourseName = "Cloud Computing",
                            StudentId = 3
                        });
                });

            modelBuilder.Entity("App.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Classification")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 14,
                            Classification = 0,
                            FirstName = "Samuel",
                            LastName = "Adams"
                        },
                        new
                        {
                            Id = 2,
                            Age = 16,
                            Classification = 1,
                            FirstName = "Jack",
                            LastName = "Daniels"
                        },
                        new
                        {
                            Id = 3,
                            Age = 17,
                            Classification = 3,
                            FirstName = "Jim",
                            LastName = "Bean"
                        },
                        new
                        {
                            Id = 4,
                            Age = 15,
                            Classification = 1,
                            FirstName = "Johnnie",
                            LastName = "Walker"
                        });
                });

            modelBuilder.Entity("App.Grade", b =>
                {
                    b.HasOne("App.Student", null)
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("App.Student", b =>
                {
                    b.Navigation("Grades");
                });
#pragma warning restore 612, 618
        }
    }
}
