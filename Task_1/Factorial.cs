using System;
class Factorial{
    static void Main(){
        Console.WriteLine("Enter a positive integer to calculate its factorial:");
        int number=Convert.ToInt32(Console.ReadLine());

        // Input validation
        while(true){
          if(number<0){
            Console.WriteLine("Enter a positive number");
            number=Convert.ToInt32(Console.ReadLine());
          }
          else{
            break;
          }
        }

        // Factorial calculation using a loop
        long factorial = 1;
        for (int i = 1; i <= number; i++){
            factorial *= i;
        }

        Console.WriteLine($"The factorial of {number} is {factorial}");
    }
}
