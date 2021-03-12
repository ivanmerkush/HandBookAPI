using Models;
using Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Views
{
    sealed public class ConsoleView : IHandbookView
    {
        private readonly IController controller;

        public ConsoleView(IController controller)
        {
            this.controller = controller;
        }

        public void Start()
        {
            while (true)
            {
                PrintMethods();
                int.TryParse(Console.ReadLine(), out int choice);
                switch (choice)
                {
                    case 1:
                        GetUsers();
                        break;
                    case 2:
                        GetUserByNameAndSurname();
                        break;
                    case 3:
                        AddUser();
                        break;
                    case 4:
                        EditUser();
                        break;
                    case 5:
                        DeleteUser();
                        break;
                    case 6:
                        LoadDB();
                        break;
                    case 7:
                        SaveDB();
                        break;
                    case 8:
                        Console.WriteLine("Bye.");
                        return;
                    default:
                        Console.WriteLine("Wrong request format/number. Try again.");
                        break;
                }
            }
        }

        public void AddUser()
        {
            Console.WriteLine("Write name surname and phone of new user:");
            string[] values = Console.ReadLine().Split(' ');
            if (values.Length != 3)
            {
                Console.WriteLine("Wrong amount of arguments.");
            }
            else
            {
                if(controller.AddUser(values[0], values[1], values[2]))
                {
                    Console.WriteLine("User was added");
                }
                else
                {
                    Console.WriteLine("This user already exists");
                }
            }
        }

        public void DeleteUser()
        {
            Console.WriteLine("Write name and surname of prey:");
            string[] values = Console.ReadLine().Split(' ');
            if (values.Length != 2)
            {
                Console.WriteLine("Wrong amount of arguments.");
            }
            else
            {
                if(controller.DeleteUser(values[0], values[1]))
                {
                    Console.WriteLine("User was deleted");
                }
                else
                {
                    Console.WriteLine("This user doesn't exists");
                }
            }
        }

        public void EditUser()
        {
            Console.WriteLine("Enter name and surname:");
            string[] values = Console.ReadLine().Split(' ');
            if (values.Length != 2)
            {
                Console.WriteLine("Wrong amount of arguments.");
            }
            else
            {
                UserInfo user = controller.GetUser(values[0], values[1]);
                if (user != null)
                {
                    Console.WriteLine("This user exists, type new name, surname and phone");
                    values = Console.ReadLine().Split(' ');
                    if (values.Length != 3)
                    {
                        Console.WriteLine("Not enough parameters");
                    }
                    else
                    {
                        if (controller.EditUser(user, values[0], values[1], values[2]))
                        {
                            Console.WriteLine("User was edited");
                        }
                        else
                        {
                            Console.WriteLine("User with this values already exists");
                        }
                    }

                }
                else
                {
                    Console.WriteLine("This user doesn't exists");
                }
            }

        }

        public void GetUserByNameAndSurname()
        {
            Console.WriteLine("Enter name and surname:");
            string[] values = Console.ReadLine().Split(' ');
            if(values.Length != 2)
            {
                Console.WriteLine("Wrong amount of arguments");
            }
            else
            {
                Console.WriteLine(controller.GetUser(values[0], values[1]));
            }
        }

        public void GetUsers()
        {
            IReadOnlyCollection<UserInfo> list = controller.GetUsers();
            foreach(UserInfo user in list)
            {
                Console.WriteLine(user);
            }
        }

        public void LoadDB()
        {
            Console.WriteLine(controller.LoadDB());
        }

        public void SaveDB()
        {
            controller.SaveDB();
        }

        private void PrintMethods()
        {
            Console.WriteLine("======================================" + Environment.NewLine + 
                "Available actions:" + Environment.NewLine + 
                "1)Get Users; " + Environment.NewLine +
                "2)Get User information by name and surname; " + Environment.NewLine +
                "3)Add User; " + Environment.NewLine +
                "4)Edit User; " + Environment.NewLine +
                "5)Delete user; " + Environment.NewLine +
                "6)Load Users;" + Environment.NewLine +
                "7)Save Users;" + Environment.NewLine +
                "8)Exit;");
        }
    }
}
