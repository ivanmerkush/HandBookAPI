using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Views
{
    sealed public class ConsoleView : HandbookView
    {
        public void Start()
        {
            while (true)
            {
                PrintMethods();
                int.TryParse(Read(), out int choice);
                switch (choice)
                {
                    case 1:
                        List<UserInfo> list = GetUsers();
                        foreach (UserInfo user in list)
                        {
                            PrintUser(user);
                        }
                        break;
                    case 2:
                        Print("Write name and surname of user:");
                        string[] values = Read().Split(' ');
                        if (values.Length != 2)
                        {
                            Print("Wrong amount of arguments.");
                        }
                        else
                        {
                            UserInfo userInfo = GetUserByNameAndSurname(values[0], values[1]);
                            if (userInfo == null)
                            {
                                Print("User with name " + values[0] + " and surname " + values[1] + " not found");
                            }
                            else
                            {
                                PrintUser(userInfo);
                            }

                        }
                        break;
                    case 3:
                        Print("Write name surname and phone of new user:");
                        values = Read().Split(' ');
                        if (values.Length != 3)
                        {
                            Print("Wrong amount of arguments.");
                        }
                        else
                        {
                            if (AddUser(values[0], values[1], values[2]))
                            {
                                Print("New user was added.");
                            }
                            else
                            {
                                Print("User already exists.");
                            }
                        }
                        break;
                    case 4:
                        Print("Write which parameter you want to change:");
                        if (Enum.TryParse(Read(), out Parameter parameter))
                        {
                            Print("Write name and surname of user");
                            values = Read().Split(' ');
                            Print("Write new value for this user");
                            string newValue = Read();
                            if (values.Length != 2)
                            {
                                Print("Wrong amount of arguments.");
                            }
                            else
                            {
                                if (EditUser(values[0], values[1], newValue, parameter))
                                {
                                    Print("User was edited.");
                                }
                            }
                        }
                        else
                        {
                            Print("There are no such parameter;");
                        }
                        break;
                    case 5:
                        Print("Write name and surname of prey:");
                        values = Read().Split(' ');
                        if (values.Length != 2)
                        {
                            Print("Wrong amount of arguments.");
                        }
                        else
                        {
                            if (DeleteUser(values[0], values[1]))
                            {
                                Print("User was deleted");
                            }
                            else
                            {
                                Print("There is no such user");
                            }
                        }
                        break;
                    case 6:
                        Print("Loading Users from file;");
                        LoadDB();
                        break;
                    case 7:
                        Print("Saving User to file");
                        SaveDB();
                        break;
                    case 8:
                        return;
                    default:
                        Print("Wrong request format/number. Try again.");
                        break;
                }
            }
        }

        public override void Print(string text) => Console.WriteLine(text);

        public override void PrintUser(UserInfo userInfo) => Console.WriteLine(userInfo);

        public override string Read() => Console.ReadLine();

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
