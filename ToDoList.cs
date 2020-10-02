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
            Console.Write("Please type out the thing you would like to add: ");
            //Add max string size
            string thingtodo = Console.ReadLine();
            todolist.Add(thingtodo);
            Console.WriteLine("Thing has been added!");
        }

        public void Remove()
        {
            int ID = 0;
            Console.WriteLine("INFO: If you do not know the ID of the thing, please cancel the command by typing '0'");
            Console.Write("Please provide the ID of the thing you would like to remove: ");
            try
            {
                ID = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException exception)
            {
                Console.WriteLine("Error! (" + exception.Message + ")");
                return;
            }

            if (ID == 0)
            {
                Console.WriteLine("Cancelled.");
                return;
            }
            todolist.RemoveAt(ID - 1);
            Console.WriteLine("Thing has been removed.");
        }

        public void Show()
        {
            Console.WriteLine("Here's a list of things you gotta do: \n");
            if (todolist.Count == 0)
            {
                Console.WriteLine("There is nothing on this list.");
                return;
            }
            foreach (string thingtodo in todolist)
            {
                Console.WriteLine((todolist.IndexOf(thingtodo) + 1) + ". " + thingtodo);
            }
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
