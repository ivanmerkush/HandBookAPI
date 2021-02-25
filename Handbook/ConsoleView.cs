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
                        foreach(UserInfo user in list)
                        {
                            PrintUser(user);
                        }
                        break;
                    case 2:
                        Print("Write name of user:");
                        string name = Read();
                        UserInfo userInfo = GetUserByName(name);
                        if(userInfo == null)
                        {
                            Print("User with name " + name + " not found");
                        }
                        else
                        {
                            PrintUser(userInfo);
                        }
                        break;
                    case 3:
                        Print("Write surname of user:");
                        string surname = Read();
                        userInfo = GetUserBySurname(surname);
                        if (userInfo == null)
                        {
                            Print("User with surname " + surname + " not found");
                        }
                        else
                        {
                            PrintUser(userInfo);
                        }
                        break;
                    case 4:
                        Print("Write name surname and phone of new user:");
                        string[] values = Read().Split(' ');
                        if(values.Length != 3)
                        {
                            Print("Wrong amount of arguments.");
                        }
                        else
                        {
                            if(AddUser(values[0], values[1], values[2]))
                            {
                                Print("New user was added.");
                            }
                            else
                            {
                                Print("User already exists.");
                            }
                        }
                        break;
                    case 5:
                        Print("Write which parameter you want to change:");
                        if(Enum.TryParse(Read(), out Parameter parameter))
                        {
                            Print("Write old and new value of this parameter:"); ;
                            values = Read().Split(' ');
                            if (values.Length != 2)
                            {
                                Print("Wrong amount of arguments.");
                            }
                            else
                            {
                                if(EditUser(values[0], values[1], parameter))
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
                    case 6:
                        Print("Write name and surname of prey:");
                        values = Read().Split(' ');
                        if (values.Length != 2)
                        {
                            Print("Wrong amount of arguments.");
                        }
                        else
                        {
                            if(DeleteUser(values[0], values[1]))
                            {
                                Print("User was deleted");
                            }
                            else
                            {
                                Print("There is no such user");
                            }
                        }
                        break;
                    case 7:
                        Print("Loading Users from file;");
                        LoadDB();
                        break;
                    case 8:
                        Print("Saving User to file");
                        SaveDB();
                        break;
                    case 9:
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
                "\n2)Get User information by name; " +
                "\n3)Get User information by surname; " +
                "\n4)Add User; " +
                "\n5)Edit User; " +
                "\n6)Delete user; " +
                "\n7)Load Users;" +
                "\n8)Save Users;" +
                "\n9)Exit;");
        }
    }
}
