using App;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace App.Data
{
  public class DataContext : DbContext
  {
    public DbSet<Student> Students { get; set; }
    public DbSet<Grade> Grades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      options.UseSqlite("Data Source=app.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      var grades = new Grade[] {
        new Grade { Id = 1, StudentId = 1, CourseName = "English I", CourseGrade = 90.00 },
        new Grade { Id = 2, StudentId = 1, CourseName = "Calculus II", CourseGrade = 70.00 },
        new Grade { Id = 3, StudentId = 2, CourseName = "Theater Appreciation", CourseGrade = 50.00 },
        new Grade { Id = 4, StudentId = 2, CourseName = "Dynamic Programming", CourseGrade = 85.00 },
        new Grade { Id = 5, StudentId = 2, CourseName = "Data Structures", CourseGrade = 15.00 },
        new Grade { Id = 6, StudentId = 3, CourseName = "Senior Design I", CourseGrade = 97.00 },
        new Grade { Id = 7, StudentId = 3, CourseName = "Cloud Computing", CourseGrade = 75.00 },
      };
      var students = new Student[] {
        new Student {Id = 1, FirstName = "Samuel", LastName = "Adams", Age = 14, Classification = CollegeClassification.Freshman},
        new Student {Id = 2, FirstName = "Jack", LastName = "Daniels", Age = 16, Classification = CollegeClassification.Sophomore},
        new Student {Id = 3, FirstName = "Jim", LastName = "Bean", Age = 17, Classification = CollegeClassification.Senior},
        new Student {Id = 4, FirstName = "Johnnie", LastName = "Walker", Age = 15, Classification = CollegeClassification.Sophomore},
      };



      modelBuilder.Entity<Student>().HasData(students);
      modelBuilder.Entity<Grade>().HasData(grades);
    }
  }
}