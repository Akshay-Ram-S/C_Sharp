using System;

class Person{
  string name;
  int age;
  public Person(string _name, int _age)
  {
    name=_name;
    age=_age;
  }
  public void Introduce()
  {
    Console.WriteLine($"Greetings from {name} and I'm {age} years old.");
  }
}

class Program
{
  static void Main()
  {
    Person person1 = new Person("John",21);
    Person person2 = new Person("Jack",19);
    Person person3 = new Person("Jill",18);

    person1.Introduce();
    person2.Introduce();
    person3.Introduce();
  }
}
