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
                        Print("Write name of user:");
                        string name = Read();
                        PrintUser(GetUserByName(name));
                        break;
                    case 2:
                        Print("Write surname of user:");
                        string surname = Read();
                        PrintUser(GetUserByName(surname));
                        break;
                    case 3:
                        Print("Write name surname and phone of new user:");
                        string[] values = Read().Split(' ');
                        AddUser(values[0], values[1], values[2]);
                        break;
                    case 4:
                        Print("Write which parameter you want to change:");
                        Enum.TryParse(Read(), out Parameter parameter);
                        Print("Write old and new value of this parameter:"); ;
                        values = Read().Split(' ');
                        EditUser(values[0], values[1], parameter);
                        break;
                    case 5:
                        Print("Write name and surname of prey:");
                        values = Read().Split(' ');
                        DeleteUser(values[0], values[1]);
                        break;
                    case 6:
                        Print("Loading Users from file;");
                        LoadDB();
                        break;
                    case 7:
                        Print("Saving User to file");
                        SaveDB();
                        break;
                    default:
                        return;
                }
            }
        }

        public override void Print(string text) => Console.WriteLine(text);

        public override void PrintUser(UserInfo userInfo) => Console.WriteLine(userInfo);

        public override string Read() => Console.ReadLine();

        private void PrintMethods()
        {
            Console.WriteLine("======================================\n" +
                "Available actions: " +
                "\n1)Get User information by name; " +
                "\n2)Get User information by surname; " +
                "\n3)Add User; " +
                "\n4)Edit User; " +
                "\n5)Delete user; " +
                "\n6)Load Users;" +
                "\n7)Save Users;");
        }
    }
}
