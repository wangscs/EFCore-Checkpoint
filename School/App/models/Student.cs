namespace App
{
  public class Student
  {
    int Id;
    string FirstName;
    string LastName;
    int Age;
    enum Classification
    {
      Freshman, Sophomore, Junior, Senior
    };
    List<Grades> Grades;
  }
}