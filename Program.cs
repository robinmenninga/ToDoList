using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ToDo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting program...");
            bool stopcondition = true;
            int userOption = 0;
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
                Console.WriteLine("0. Quit");
                try
                {
                    userOption = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException exception)
                {
                    Console.WriteLine("Error! (" + exception.Message + ")");
                }
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
                Console.WriteLine();
            }
        }
    }
}
