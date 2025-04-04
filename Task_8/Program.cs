using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;


public interface IRepository<T> where T : class{
    void Add(T item);
    T Get(int id);
    void Update(T item);
    void Delete(int id);
    IEnumerable<T> GetAll();
}

public class InMemoryRepository<T> : IRepository<T> where T : class{
    private readonly List<T> _items = new List<T>();
    private int _nextId = 1;

    public void Add(T item){
        var property = typeof(T).GetProperty("Id");
        if (property != null){
            property.SetValue(item, _nextId++);
        }
        _items.Add(item);
    }

    public T Get(int id){
        return _items.FirstOrDefault(item => (int)item.GetType().GetProperty("Id").GetValue(item) == id);
    }

    public void Update(T item){
        var id = (int)item.GetType().GetProperty("Id").GetValue(item);
        var existing = Get(id);
        if (existing != null){
            _items[_items.IndexOf(existing)] = item;
        }
    }

    public void Delete(int id){
        var item = Get(id);
        if (item != null){
            _items.Remove(item);
        }
    }

    public IEnumerable<T> GetAll(){
        return _items;
    }
}


public class Student{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}


class Program{
    static void Main(){
        IRepository<Student> repository = new InMemoryRepository<Student>();
        string choice;

        do{
            Console.WriteLine("\n1. Add | 2. View | 3. Update | 4. Delete | 5. Exit");
            Console.Write("Choose an option: ");
            choice = Console.ReadLine();

            switch (choice){
                case "1":
                    Console.Write("Name: ");
                    var name = Console.ReadLine();
                    Console.Write("Age: ");
                    var age = int.Parse(Console.ReadLine());
                    repository.Add(new Student { Name = name, Age = age });
                    break;

                case "2":
                    foreach (var std in repository.GetAll())
                        Console.WriteLine($"ID: {std.Id}, Name: {std.Name}, Age: {std.Age}");
                    break;

                case "3":
                    Console.Write("ID to update: ");
                    var updateId = int.Parse(Console.ReadLine());
                    var student = repository.Get(updateId);
                    if (student != null){
                        Console.Write("New Name: ");
                        student.Name = Console.ReadLine();
                        Console.Write("New Age: ");
                        student.Age = int.Parse(Console.ReadLine());
                        repository.Update(student);
                    }
                    else
                        Console.WriteLine("Not found.");
                    break;

                case "4":
                    Console.Write("ID to delete: ");
                    repository.Delete(int.Parse(Console.ReadLine()));
                    break;
            }
        } while (choice != "5");
    }
}
