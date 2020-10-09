using System;
using System.IO;

namespace ToDo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting program...");
            bool stopcondition = true;
            int userOption;
            if (!File.Exists("todolist.txt"))
            {
                Console.WriteLine("No list found, creating a new list");
                File.Create("todolist.txt").Dispose();
            }
            Console.WriteLine("Opening list...");
            ToDoList list = new ToDoList();
            list.Open();
            Console.Write("Welcome user! ");
            while (stopcondition)
            {
                Console.WriteLine("What would you like to do? (Input number) \n");
                list.PrintOptions();
                Console.WriteLine("0. Save and quit");
                try
                {
                    userOption = (int) Char.GetNumericValue(Console.ReadKey().KeyChar);
                    if (userOption == 0)
                    {
                        Console.WriteLine("Quitting...");
                        list.Save();
                        stopcondition = false;
                    }
                    else
                    {
                        list.Execute(userOption);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error! Not a number.");
                    Console.ReadLine();
                    Console.Clear();
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Error! Number too big.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
