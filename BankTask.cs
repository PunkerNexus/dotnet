using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banktask
{
    class Program
    {
        public static IСustomer[] _alllist = new IСustomer[]
        {
            new Client() { Number = "0981111111", Password = "123", Balance = 1000},
            new Client() { Number = "0982222222", Password = "123", Balance = 1000},
            new Client() { Number = "0983333333", Password = "123", Balance = 1000},
            new Client() { Number = "0984444444", Password = "123", Balance = 1000},
            new Client() { Number = "0985555555", Password = "123", Balance = 1000},
            new Admin() { Number = "0981235454", Password = "321", Balance = 5000}
        };

        static void Main(string[] args)
        {
            while (true)
            {
                Registration();
            }
        }

        public static void Registration()
        {
            int count = 3;
            while (true)
            {
                Console.WriteLine("Enter your phone number: ");
                string trynumber = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                string trypassword = Console.ReadLine();

                for (int i = 0; i < _alllist.Count(); i++)
                {
                    var user = _alllist[i];

                    if (user.Number == trynumber && user.Password == trypassword)
                    {
                        Console.WriteLine("You are logged in.");
                        ShowDisplay(user);
                        break;
                    }
                    else
                    {
                        //while (true)
                        //{
                            count--;
                            Console.WriteLine($"Incorrect login or password, try again. Left: {count}.");
                            if (count <= 0)
                            {
                                Console.WriteLine("Acces denied.");
                                return;
                            }
                            Console.WriteLine("Enter your phone number: ");
                            trynumber = Console.ReadLine();
                            Console.WriteLine("Enter password: ");
                            trypassword = Console.ReadLine();

                            if (user.Number == trynumber && user.Password == trypassword)
                            {
                                Console.WriteLine("You are logged in.");
                                ShowDisplay(user);
                                return;
                            }
                        //}
                    }
                }
            }
        }

        public static void ShowDisplay(IСustomer user)
        {
            Console.WriteLine("\tMain screen.");
            if (CheckAdmClient(user))
            {
                Console.WriteLine("Hello, Admin!");
                while (true)
                {
                    Console.WriteLine("Select an action by choosing number.");
                    Console.WriteLine("1. Withdraw money. 2. Show balance. 3. Delete Client. 4. Exit.");

                    string actionAdmin = Console.ReadLine();
                    switch(actionAdmin)
                    {
                        case "1":
                            //some
                            break;
                        case "2":
                            //some
                            break;
                        case "3":
                            //some
                            break;
                        case "4":
                            return;
                        default:
                            Console.WriteLine("Invalid command. Try again.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Hello, Client!");
                while (true)
                {
                    Console.WriteLine("Select an action by choosing number.");
                    Console.WriteLine("1. Withdraw money. 2. Show balance. 3. Exit.");

                    string actionAdmin = Console.ReadLine();
                    switch (actionAdmin)
                    {
                        case "1":
                            //some
                            break;
                        case "2":
                            //some
                            break;
                        case "3":
                            return;
                        default:
                            Console.WriteLine("Invalid command. Try again.");
                            break;
                    }
                }
            }
        }

        static bool CheckAdmClient(IСustomer user)
        {
            if (user is Admin)
            {
                return true;
            }
            return false;
        }
    }

    interface IСustomer
    {
        string Number { get; set; }
        string Password { get; set; }
        int Balance { get; set; }
    }

    class Client : IСustomer
    {
        public string Number { get; set; }
        public string Password { get; set; }
        public int Balance { get; set; }
    }

    class Admin : IСustomer
    {
        public string Number { get; set; }
        public string Password { get; set; }
        public int Balance { get; set; }
    }
}