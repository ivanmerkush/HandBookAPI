using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Models;
using InterfacesLibrary.Interfaces.Controllers;
using InterfacesLibrary.Interfaces.Views;
using Controllers;

namespace Views
{
    sealed public class ConsoleView : IUserView
    {
        public IController Controller { get; }

        private readonly string pattern = @"\b^(375)+\d{9}\b";

        public ConsoleView()
        {
            Controller = Helper.GetConsoleController(this);
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
                        PrintUsers();
                        break;
                    case 2:
                        GetUser();
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
                if(Regex.IsMatch(values[2], pattern))
                {
                    Controller.AddUser(new UserInfo(values[0], values[1], values[2]));
                }
                else
                {
                    Console.WriteLine("Wrong phone number");
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
                Controller.DeleteUser(new UserInfo(values[0], values[1], string.Empty));
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
                IReadOnlyCollection<UserInfo> users = Controller.GetUserByName(values[0], values[1]);
                if (users.Count == 0)
                {
                    Console.WriteLine("This user exists, type new name, surname and phone");
                    values = Console.ReadLine().Split(' ');
                    if (values.Length != 3)
                    {
                        Console.WriteLine("Not enough parameters");
                    }
                    else
                    {
                        if(Regex.IsMatch(values[2], pattern))
                        {
                            foreach (UserInfo userInfo in users)
                            {
                                Controller.EditUser(new UserInfo(userInfo.Id, values[0], values[1], values[2]));
                            }
                        }
                        else
                        {
                            Console.WriteLine("Wrong phone number");
                        }
                    }

                }
                else
                {
                    Console.WriteLine("This user doesn't exists");
                }
            }

        }

        public void GetUser()
        {
            Console.WriteLine("Would you like to find by 1)Name or 2)Phone");
            if(!int.TryParse(Console.ReadLine(), out int request))
            {
                Console.WriteLine("Wrong request.");
            }
            else
            {
                switch (request)
                {
                    case 1:
                        Console.WriteLine("Enter name and surname:");
                        string[] values = Console.ReadLine().Split(' ');
                        if (values.Length != 2)
                        {
                            Console.WriteLine("Wrong amount of arguments");
                        }
                        else
                        {
                            foreach (UserInfo user in Controller.GetUserByName(values[0], values[1]))
                            {
                                Console.WriteLine(user);
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter phone");
                        string phone = Console.ReadLine();
                        if (Regex.IsMatch(phone, pattern))
                        {
                            Console.WriteLine(Controller.GetUserByPhone(phone));
                        }
                        break;
                    default:
                        break;
                }
            }
                
        }

        public void ShowMessageBox(string text) => Console.WriteLine(text);
        public void AppendNotifierText(string text) => Console.WriteLine(text);

        public IReadOnlyCollection<UserInfo> GetUsers() => Controller.GetUsers();

        public void LoadDB()
        {
            Controller.LoadDB();
        }

        public void SaveDB()
        {
            Controller.SaveDB();
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

        private void PrintUsers()
        {
            foreach (UserInfo user in GetUsers())
            {
                Console.WriteLine(user);
            }
        }

        public void EnableEdittingUsers()
        {
            
        }

        public void DisableEdittingUsers()
        {
            
        }
    }
}
