using System;
using System.Collections.Generic;

public class Task
{
    public string Description { get; set; }
    public bool IsCompleted { get; set; }

    public Task(string description)
    {
        Description = description;
        IsCompleted = false;
    }

    public override string ToString()
    {
        return $"{Description} - {(IsCompleted ? "Completed" : "Pending")}";
    }
}

class ToDoApp
{
    static List<Task> tasks = new List<Task>();

    static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Complete Task");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    ViewTasks();
                    break;
                case "3":
                    CompleteTask();
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.Write("Enter task description: ");
        string description = Console.ReadLine();
        tasks.Add(new Task(description));
    }

    static void ViewTasks()
    {
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i]}");
        }
    }

    static void CompleteTask()
    {
        ViewTasks();
        Console.Write("Enter the number of the task to complete: ");
        int taskNumber;
        if (int.TryParse(Console.ReadLine(), out taskNumber) && taskNumber <= tasks.Count)
        {
            tasks[taskNumber - 1].IsCompleted = true;
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
    }
}
