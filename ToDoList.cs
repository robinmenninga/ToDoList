using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ToDo
{
    class ToDoList
    {
        List<string> options = new List<string> {"Add to list", "Remove from list", "Show items on list" };
        Dictionary<int, string> todolist = new Dictionary<int, string>();

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
                return;
            }
            //create new ID
            int ID = GenerateID(1);
            todolist.Add(ID, thingtodo);
            Console.WriteLine("Thing has been added!");
        }

        public int GenerateID(int ID)
        {
            if (todolist.Keys.Contains(ID))
            {
                return GenerateID(ID + 1);
            }
            return ID;
        }

        public void Remove()
        {
            Console.Clear();
            if (todolist.Count == 0)
            {
                Console.WriteLine("There is nothing to remove!");
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
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error! Number too big.");
                return;
            }

            if (ID == 0)
            {
                Console.WriteLine("Cancelled.");
                return;
            }
            if (!todolist.Keys.Contains(ID))
            {
                Console.WriteLine("Error! ID doesn't exist.");
                return;
            }

            todolist.Remove(ID);
            Console.WriteLine("Thing has been removed.");
        }

        public void Show()
        {
            Console.Clear();
            if (todolist.Count == 0)
            {
                Console.WriteLine("There is nothing on this list.");
                return;
            }
            Console.WriteLine("Here's a list of things you got to do: \n");
            foreach (KeyValuePair<int, string> thingtodo in todolist)
            {
                Console.WriteLine(thingtodo.Key + ".   " + thingtodo.Value);
            }
        }
        public void Save()
        {
            List<string> todoStringList = new List<string>();
            foreach (KeyValuePair<int, string> thing in todolist)
            {
                string item = thing.Key + " " + thing.Value;
                todoStringList.Add(item);
            }
                File.WriteAllLines("todolist.txt", todoStringList);
        }
        public void Open()
        {
            foreach (string fileline in File.ReadAllLines("todolist.txt"))
            {
                int ID = 0;
                string[] filelineArray = fileline.Split(" ");
                try
                {
                    ID = Convert.ToInt32(filelineArray[0]);
                } catch (FormatException)
                {
                    Console.WriteLine("Error! File corrupted.");
                    string newFileName = CreateCorruptedFile();
                    File.Move("todolist.txt", newFileName);
                    Console.WriteLine("The corrupted file has been renamed to " + newFileName + ".");
                    Console.WriteLine("Creating new list...");
                    File.Create("todolist.txt").Dispose();
                    return;
                }
                todolist.Add(ID, string.Join(" ", filelineArray[1..filelineArray.Length]));
            }
        }

        private string CreateCorruptedFile()
        {
            string GUID = Guid.NewGuid().ToString();
            string newFileName = "CORRUPTED_todolist_" + GUID + ".txt";
            if (File.Exists(newFileName))
            {
                CreateCorruptedFile();
            }
            return newFileName;
        }

        public void Execute(int optionID)
        {
            switch (optionID)
            {
                default:
                    Console.WriteLine("Error! Unknown option.");
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
            Console.ReadLine();
            Console.Clear();
        }
    }
}
