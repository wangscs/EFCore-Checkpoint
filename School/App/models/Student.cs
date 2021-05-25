using System.Collections.Generic;

namespace App
{
  public enum CollegeClassification
  {
    Freshman,
    Sophomore,
    Junior,
    Senior
  };
  public class Student
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public CollegeClassification Classification { get; set; }
    public List<Grade> Grades { get; set; }
  }
}