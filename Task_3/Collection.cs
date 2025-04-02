using System;
using System.Collections.Generic;
using System.Security.Cryptography;
class Program{

  static void AddName(List<String> Names){
    Console.WriteLine("Enter name to be added :");
    string name_to_add = Console.ReadLine().ToUpper(); // Converting string to uppercase using ToUpper()
    if(!string.IsNullOrEmpty(name_to_add)){
      Names.Add(name_to_add.Trim()); // Removing leading and trailing whitespaces in string
    }
    Console.WriteLine();
  }

  static void RemoveName(List<String> Names){
    Console.WriteLine("Enter name to be deleted :");
    string name_to_delete = Console.ReadLine().ToUpper().Trim();
    if(!string.IsNullOrEmpty(name_to_delete)){

      Names.Remove(name_to_delete);
    }
    Console.WriteLine();
  }

  static void DisplayNames(List<String> Names){
    foreach(string name in Names){  // The foreach loop in C# is used to iterate over elements in a collection
      Console.WriteLine(name);
    }
    Console.WriteLine();
  }

  static void Main(){
    List<string> Names = new List<string>();
    int choice;
    while(true){
      Console.WriteLine("Choose the action");
      Console.WriteLine("1. Add Name \n2. Remove Name \n3. Display Names \n4. End");
      choice=Convert.ToInt32(Console.ReadLine());
      if(choice==4){
        break;
      }
      if(choice==1){
        AddName(Names);
      }
      else if(choice==2){
        RemoveName(Names);
      }
      else{
        DisplayNames(Names);
      }
    }

  }
}
