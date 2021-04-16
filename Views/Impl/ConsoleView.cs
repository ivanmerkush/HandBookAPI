﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Models;
using InterfacesLibrary;
using Controllers;

namespace Views
{
    sealed public class ConsoleView : IUserView
    {
        public IController Controller { get; }
        public string MessageBoxText { set => Console.WriteLine(value); }
        public string NotifierText { set => Console.WriteLine(value); }

        public UserInfo SelectedUser => throw new NotImplementedException();

        public bool EditingVisible 
        { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }

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
                        GetUsers();
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
                    //if (Controller.AddUser(values[0], values[1], values[2]))
                    //{
                    //    Console.WriteLine("User was added");
                    //}
                    //else
                    //{
                    //    Console.WriteLine("This user already exists");
                    //}
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
                //if(Controller.DeleteUser(new UserInfo(values[0], values[1], string.Empty()))
                //{
                //    Console.WriteLine("User was deleted");
                //}
                //else
                //{
                //    Console.WriteLine("This user doesn't exists");
                //}
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
                                //if (Controller.EditUser(userInfo, values[0], values[1], values[2]))
                                //{
                                //    Console.WriteLine("User was edited");
                                //}
                                //else
                                //{
                                //    Console.WriteLine("User with this values already exists");
                                //}
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

        public void GetUsers()
        {
            IReadOnlyCollection<UserInfo> list = Controller.GetUsers();
            foreach(UserInfo user in list)
            {
                Console.WriteLine(user);
            }
        }

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
    }
}
