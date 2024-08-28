using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

namespace Classes
{
    public class BankMethods
    {
        private static string[,] usernames = { { "John123", "password123" }, { "caleb123", "hello123" } };

        private List<UserAccount> UserAccounts = new List<UserAccount>();

        // Dictionary to hold user details
        private static Dictionary<string, Dictionary<string, dynamic>> UserDetails = new Dictionary<string, Dictionary<string, dynamic>>();

        // Constructor to initialize the list with some user accounts
        public BankMethods()
        {
            UserAccounts.Add(new UserAccount("John", 300.00m, "password123"));
            UserAccounts.Add(new UserAccount("Mark", 300.00m, "password123"));
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            // Deposit logic here
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            // Withdrawal logic here
        }

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Group 5 Bank\nPlease choose an option:\n1: Login\n2: Register");
            string stringSelection = Console.ReadLine();

            if (!string.IsNullOrEmpty(stringSelection) && int.TryParse(stringSelection, out int selection))
            {
                if (selection == 1)
                {
                    Login();
                }
                else if (selection == 2)
                {
                    Register();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"{selection} is not a valid selection...\nPlease enter either 1 or 2");
                    Menu();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"{stringSelection} is not a valid selection...\nPlease enter either 1 or 2");
                Menu();
            }
        }


        private static void Login()
        {
            int usernameCounter = 0;
            while (usernameCounter < 4)
            {
                Console.Clear();
                string message = usernameCounter == 0 ? "Please enter your username" : $"User Name not found!\nYou have {(4 - usernameCounter)} attempts left Please Try again";
                Console.WriteLine(message);
                string inputUsername = Console.ReadLine();
                foreach (string dictUsername in UserDetails.Keys)
                {
                    if (dictUsername == inputUsername)
                    {
                        PasswordChecker(dictUsername);
                        usernameCounter = 999;
                    }
                }
                usernameCounter++;
            }
            if (usernameCounter == 4)
            {
                Console.WriteLine("You have exceed your attempts... Press any Key to return home.");
                Console.ReadLine();
                Menu();
            }
        }

        private static void PasswordChecker(string dictUsername)
        {
            int passwordCounter = 0;
            while (passwordCounter < 4)
            {
                Console.Clear();
                string message = passwordCounter == 0 ? "Please enter your password" : $"Incorrect password!\nYou have {(4 - passwordCounter)} attempts left Please Try again";
                Console.WriteLine($"{message}");
                string inputPassword = Console.ReadLine();

                if (inputPassword == UserDetails[dictUsername]["Password"])
                {
                    Console.Clear();
                    Console.WriteLine($"Welcome back {dictUsername}");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    VerifiedUserMenu(dictUsername);
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect password...");
                    passwordCounter++;
                }
            }
            if (passwordCounter == 4)
            {
                Console.WriteLine("You have exceeded your attempts... Press any Key to return home.");
                Console.ReadLine();
                Menu();
            }
        }

        private static void VerifiedUserMenu(string dictUsername)
        {
            Console.Clear();
            Console.WriteLine($"How can we help {dictUsername}:\n1: View Balance\n2: Deposit\n3: Withdraw\n4: Transfer\n5: Quit");
            string stringSelection = Console.ReadLine();

            try
            {
                int selection = Int32.Parse(stringSelection);
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("You Selected View Balance");
                        break;
                    case 2:
                        Console.WriteLine("You Selected Deposit");
                        break;
                    case 3:
                        Console.WriteLine("You Selected Withdraw");
                        break;
                    case 4:
                        Console.WriteLine("You Selected Transfer");
                        break;
                    case 5:
                        Console.WriteLine("Quit");
                        Menu();
                        break;
                    default:
                        throw new Exception();
                }

                Console.WriteLine("This is the end of the prototype\nPress 1 to go back or 2 to logout");
                selection = Int32.Parse(Console.ReadLine());
                if (selection == 1)
                {
                    Console.Clear();
                    VerifiedUserMenu(dictUsername);
                }
                else if (selection == 2)
                {
                    Console.Clear();
                    Menu();
                }
                else
                {
                    throw new Exception("Return to main menu");
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine($"{stringSelection} is not a valid selection...\nPlease select from the Menu");
                VerifiedUserMenu(dictUsername);
            }
        }

        public static void Register()
        {
            Console.WriteLine("Enter Your Username");

            string username;
            string[] options = { "Email", "Age", "Phone", "Password" };

            while (true)
            {
                username = Console.ReadLine();

                bool usernameExists = false;
                foreach (var pair in UserDetails)
                {
                    if (username == pair.Key) usernameExists = true;
                }
                if (!usernameExists) break;

                Console.WriteLine("This username already exists, please choose another username");
            }

            UserDetails.Add(username, new Dictionary<string, dynamic>());

            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"Enter Your {options[i]}");
                UserDetails[username].Add(options[i], Console.ReadLine());
            }
        }
    }
}
