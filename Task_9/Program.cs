using System;
using System.Reflection;

// Step 1: Define the custom attribute
[AttributeUsage(AttributeTargets.Method)]
public class RunnableAttribute : Attribute{
}

// Step 2: Create classes with methods marked with [Runnable]
public class Task1{
    [Runnable]
    public static void ExecuteTask1(){
        Console.WriteLine("Task A is running...");
    }
}

public class Task2{
    [Runnable]
    public static void ExecuteTask2(){
        Console.WriteLine("Task B is running...");
    }
}

public class Task3{
    public static void NotRunnableMethod(){
        Console.WriteLine("This should not run.");
    }
}

class Program{
    static void Main(string[] args){
        // Step 3: Use reflection to find and invoke methods with [Runnable]
        Assembly currentAssembly = Assembly.GetExecutingAssembly();
        foreach (Type type in currentAssembly.GetTypes()){
            foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)){
                if (method.GetCustomAttribute<RunnableAttribute>() != null){
                    // Step 4: Create an instance if the method is not static
                    object classInstance = null;
                    if (!method.IsStatic){
                        classInstance = Activator.CreateInstance(type);
                    }
                    // Step 5: Invoke the method
                    method.Invoke(classInstance, null);
                }
            }
        }
    }
}
