using System;
using System.Collections.Generic;
using System.IO;

namespace ToDo
{
    class ToDoList
    {
        List<string> options = new List<string> {"Add to list", "Remove from list", "Show items on list" };
        List<string> todolist = new List<string>();

        public void PrintOptions()
        {
            foreach (string option in options)
            {
                Console.WriteLine((options.IndexOf(option) + 1) + ". " + option);
            }
            
        }

        public void Add()
        {
            Console.Clear();
            Console.WriteLine("INFO: The input must have a max size of 50 characters");
            Console.Write("Please type out the thing you would like to add: ");
            string thingtodo = Console.ReadLine();
            if (thingtodo.Length > 50)
            {
                Console.WriteLine("Error! Input is longer than 50 characters.");
                Console.ReadLine();
                Console.Clear();
                return;
            }
            todolist.Add(thingtodo);
            Console.WriteLine("Thing has been added!");
            Console.ReadLine();
            Console.Clear();
        }

        public void Remove()
        {
            Console.Clear();
            if (todolist.Count == 0)
            {
                Console.WriteLine("There is nothing to remove!");
                Console.ReadLine();
                Console.Clear();
                return;
            }
            int ID = 0;
            Console.WriteLine("INFO: If you do not know the ID of the thing, please cancel the command by typing '0'");
            Console.Write("Please provide the ID of the thing you would like to remove: ");
            try
            {
                ID = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Error! Not a number.");
                Console.ReadLine();
                Console.Clear();
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error! Number too big.");
                Console.ReadLine();
                Console.Clear();
                return;
            }

            if (ID == 0)
            {
                Console.WriteLine("Cancelled.");
                Console.ReadLine();
                Console.Clear();
                return;
            }
            try
            {
                todolist.RemoveAt(ID - 1);
                Console.WriteLine("Thing has been removed.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Error! ID doesn't exist");
            }
            Console.ReadLine();
            Console.Clear();
        }

        public void Show()
        {
            Console.Clear();
            if (todolist.Count == 0)
            {
                Console.WriteLine("There is nothing on this list.");
                Console.ReadLine();
                Console.Clear();
                return;
            }
            Console.WriteLine("Here's a list of things you got to do: \n");
            foreach (string thingtodo in todolist)
            {
                Console.WriteLine((todolist.IndexOf(thingtodo) + 1) + ". " + thingtodo);
            }
            Console.ReadLine();
            Console.Clear();
        }
        public void Save()
        {
            foreach (string thing in todolist)
            {
                File.WriteAllLines("todolist.txt", todolist);
            }
        }
        public void Open()
        {
            foreach (string fileline in File.ReadAllLines("todolist.txt"))
            {
                todolist.Add(fileline);
            }
        }

        public void Execute(int optionID)
        {
            switch (optionID)
            {
                default:
                    Console.WriteLine("Error! Unknown option.");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 1:
                    Add();
                    break;
                case 2:
                    Remove();
                    break;
                case 3:
                    Show();
                    break;
            }
        }
    }
}
