using System;
using System.Collections.Generic;
using System.Linq;

class Linq{
  public class Student{
    public string name;
    public int age;
    public int grade;
    public Student(string _name, int _age, int _grade){
      name = _name;
      age = _age;
      grade = _grade;
    }
  }

  static void Main(){

    List<Student> students = new List<Student>{
      new Student("John",18,95),
      new Student("Jim",19,34),
      new Student("Jerry",18,75),
      new Student("Jey",20,47),
      new Student("Jack",18,53),
      new Student("Jacob",20,98),
      new Student("Jude",18,83),
      new Student("Joel",18,71),
      new Student("Jurgen",20,87),
      new Student("Jade",19,64)
    };
    
    int threshold = 80;
    var FilteredStudents = students
                      .Where(s => s.grade > threshold) // Filtering students with grade > 80
                      .OrderBy(s => s.name); // Ordering those students by name
    
    Console.WriteLine("Filtered Students list :");

    foreach(var std in FilteredStudents){
      Console.WriteLine($"Name: {std.name}, Grade: {std.grade}, Age: {std.age}");
    }
                      
  }
  
}