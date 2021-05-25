using System;
using System.Linq;
using App.Data;

namespace App
{
  class Program
  {
    static void Main(string[] args)
    {
      var database = new DataContext();
      var students = database.Students.ToList();

      // Associate Student Grades
      var sam = database.Students
        .Where(student => student.FirstName == "Samuel")
        .FirstOrDefault();
      var samsGrades = database.Grades
        .Where(grade => grade.StudentId == sam.Id)
        .ToList();
      sam.Grades = samsGrades;

      var jack = database.Students
        .Where(student => student.FirstName == "Jack")
        .FirstOrDefault();
      var jacksGrades = database.Grades
        .Where(grade => grade.StudentId == jack.Id)
        .ToList();
      jack.Grades = jacksGrades;

      var jim = database.Students
        .Where(student => student.FirstName == "Jim")
        .FirstOrDefault();
      var jimsGrades = database.Grades
        .Where(grade => grade.StudentId == jim.Id)
        .ToList();
      jim.Grades = jimsGrades;

      var john = database.Students
        .Where(student => student.FirstName == "Johnnie")
        .FirstOrDefault();
      var johnsGrades = database.Grades
        .Where(grade => grade.StudentId == john.Id)
        .ToList();
      john.Grades = johnsGrades;

      database.SaveChanges();

      // 1
      Console.WriteLine("--- List of All Students ---");
      foreach (var student in students)
      {
        Console.WriteLine($"Id: {student.Id} | Name: {student.FirstName} {student.LastName}");
      }

      // 2
      Console.WriteLine("--- Given a students name, Show their grades ---");

      Console.WriteLine($"Student: {jim.FirstName} {jim.LastName}");
      jim.Grades.ToList().ForEach(grade =>
      {
        Console.WriteLine($"Grade: {grade.CourseGrade}");
      });

      // 3
      Console.WriteLine("--- Given a students name, find their avg grade ---");
      var avgGrade = 0.00;
      jim.Grades.ToList().ForEach(grade => avgGrade += grade.CourseGrade);
      avgGrade /= jim.Grades.ToList().Count;
      Console.WriteLine($"Student: {jim.FirstName} {jim.LastName}");
      Console.WriteLine($"Average GPA: {avgGrade}");

      // 4
      Console.WriteLine("--- Find the student with the highest avg grade ---");
      var highestScorer = "";
      var highestAvg = 0.00;
      foreach (var student in students)
      {
        avgGrade = 0;
        student.Grades.ToList().ForEach(grade => avgGrade += grade.CourseGrade);
        avgGrade /= student.Grades.ToList().Count;
        if (avgGrade > highestAvg)
        {
          highestScorer = student.FirstName;
          highestAvg = avgGrade;
        }
      }
      Console.WriteLine($"Student with the highest avg grade: {highestScorer}");

      // 5
      Console.WriteLine("--- Find the student that took the most number of courses ---");
      var highestNumCourses = 0;
      var highestNumCourseStudent = "";
      foreach (var student in students)
      {
        var studentNumClasses = student.Grades.ToList().Count;
        if (studentNumClasses > highestNumCourses)
        {
          highestNumCourseStudent = student.FirstName;
          highestNumCourses = studentNumClasses;
        }
      }
      Console.WriteLine($"Student with highest number of courses: {highestNumCourseStudent}");

      // 6
      Console.WriteLine("--- Find a student that didnt take any courses ---");
      foreach (var student in students)
      {
        if (student.Grades.ToList().Count == 0)
        {
          Console.WriteLine($"Student '{student.FirstName} {student.LastName}' is not taking any courses");
        }
      }

      // 7
      Console.WriteLine("--- Find the avg grade for all Sophomores ---");
      var sophomoreAvgGrade = 0.00;
      var numCourses = 0;
      foreach (var student in students)
      {
        if (student.Classification == CollegeClassification.Sophomore)
        {
          student.Grades.ToList().ForEach(grade => sophomoreAvgGrade += grade.CourseGrade);
          numCourses += student.Grades.ToList().Count;
        }
      }
      sophomoreAvgGrade /= numCourses;
      Console.WriteLine($"Average Grade of all sophomores: {sophomoreAvgGrade}");
    }
  }
}
