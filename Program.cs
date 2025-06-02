using System;
using Assignment6;
using Assignment6.Utilities;
using System.Threading;

namespace Assignment6
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Init device
            Console.Write("Enter username: ");
            string user = Console.ReadLine();

            Console.Write("Enter password: ");
            string pass = Console.ReadLine();

            MobileDevice device = new MobileDevice(user, pass);

            // 2. Login flow
            bool loggedIn = false;
            while (!loggedIn)
            {
                Console.Write("Login - username: ");
                string u = Console.ReadLine();

                Console.Write("Login - password: ");
                string p = Console.ReadLine();

                try
                {
                    if (device.Login(u, p))
                    {
                        Console.WriteLine("Login successful.\n");
                        loggedIn = true;
                    }
                    else
                    {
                        Console.WriteLine("Login failed.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return; // Exit program on block
                }
            }

            // 3. Menu
            while (true)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Add new app");
                Console.WriteLine("2. Show most popular navigation app");
                Console.WriteLine("3. Navigate to address (not yet implemented)");
                Console.WriteLine("4. Print all installed apps");
                Console.WriteLine("5. Sort apps");
                Console.WriteLine("6. Exit");

                Console.Write("Choose: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddNewApp(device);
                        break;

                    case "2":
                        try
                        {
                            Console.WriteLine($"Most popular nav app:\n{device.PopularNavigationApp()}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "3":
                        Console.WriteLine("🚧 Navigation to address not implemented yet.");
                        break;

                    case "4":
                        Console.WriteLine(device.ToString());
                        break;

                    case "6":
                        Console.WriteLine("Bye bye.");
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void AddNewApp(MobileDevice device)
        {
            Console.Write("Choose app type (1 = Social, 2 = Navigation): ");
            string type = Console.ReadLine();

            Console.Write("App name: ");
            string name = Console.ReadLine();

            Console.Write("App price: ");
            int price = int.Parse(Console.ReadLine());

            if (type == "1") // Social
            {
                Console.Write("Rating (1-5): ");
                int rating = int.Parse(Console.ReadLine());

                Console.Write("Is for organization? (true/false): ");
                bool isOrg = bool.Parse(Console.ReadLine());

                Social socialApp = new Social(name, price, rating, isOrg);
                device.AddApp(socialApp);
            }
            else if (type == "2") // Navigation
            {
                // You’ll need to implement Navigation constructor here with dummy or real input
                Console.WriteLine("🚧 Add Navigation App not yet implemented.");
            }
            else
            {
                Console.WriteLine("Invalid app type.");
            }
        }
    }
}
