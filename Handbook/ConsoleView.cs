using Models;
using Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Views
{
    sealed public class ConsoleView : IHandbookView
    {
        private readonly BookController controller;

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

        public ConsoleView()
        {
            controller = new BookController();
            controller.ControllerEvent += OnEndingRequest;
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
                if(!controller.AddUser(values[0], values[1], values[2]))
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
                if(!controller.DeleteUser(values[0], values[1]))
                {
                    Console.WriteLine("This user doesn't exists");
                }
            }
        }

        public void EditUser()
        {
            Console.WriteLine("Enter parameter you want to be edited");
            if(!Enum.TryParse(Console.ReadLine(), out Parameters parameter))
            {
                Console.WriteLine("There are no this parameter");
            }
            else
            {
                Console.WriteLine("Enter name and surname:");
                string[] values = Console.ReadLine().Split(' ');
                Console.WriteLine("Write new value for this user");
                string newValue = Console.ReadLine();
                if (values.Length != 2)
                {
                    Console.WriteLine("Wrong amount of arguments.");
                }
                else
                {
                    if(!controller.EditUser(values[0], values[1], newValue, parameter))
                    {
                        Console.WriteLine("This user doesn't exists");
                    }
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
                controller.GetUser(values[0], values[1]);
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
            controller.LoadDB();
        }

        public void SaveDB()
        {
            controller.SaveDB();
        }

        private void OnEndingRequest(object sender, ActionEventArgs args)
        {
            switch(args.action)
            {
                case Actions.GetAll:
                    Console.WriteLine("All users from list");
                    break;
                case Actions.Get:
                    Console.WriteLine("Here is user's info");
                    break;
                case Actions.Add:
                    Console.WriteLine("A new user was added");
                    break;
                case Actions.Edit:
                    Console.WriteLine("A user was edited");
                    break;
                case Actions.Delete:
                    Console.WriteLine("User was removed from list");
                    break;
                case Actions.Load:
                    Console.WriteLine("User's list was loaded from file");
                    break;
                case Actions.Save:
                    Console.WriteLine("User's lsit saved to file");
                    break;
            }
            if(args.userInfo != null)
            {
                Console.WriteLine(args.userInfo);
            }
        }

        private void PrintMethods()
        {
            Console.WriteLine("======================================\n" +
                "Available actions:" +
                "\n1)Get Users; " +
                "\n2)Get User information by name and surname; " +
                "\n3)Add User; " +
                "\n4)Edit User; " +
                "\n5)Delete user; " +
                "\n6)Load Users;" +
                "\n7)Save Users;" +
                "\n8)Exit;");
        }
    }
}
