using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace ToDo
{
    class Program
    {
        static void Main(string[] args)
        {
            int userOption = 0;
            Console.WriteLine("Do you want to create a new list (1) or do you want to open an existing list (2)? (Insert number)");
            try
            {
                userOption = Convert.ToInt32(Console.ReadLine());

            }
            catch (FormatException exception)
            {
                Console.WriteLine("Error! (" + exception.Message + ")");
            }
            if (userOption == 1)
            {
                Console.WriteLine("Creating new list...");
                OpenFileDialog ofd = new OpenFileDialog();
                //make new list
            }
            if (userOption == 2)
            {
                //open list
            }


            Console.WriteLine("Starting up list...");
            
            ToDoList list = new ToDoList();
            Console.Write("Welcome user! ");
            while (true)
            {
                Console.WriteLine("What would you like to do? (Input number) \n");
                list.PrintOptions();
                try
                {
                    userOption = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException exception)
                {
                    Console.WriteLine("Error! (" + exception.Message + ")");
                }
                list.Execute(userOption);
                Console.WriteLine();
            }
        }
    }
}
