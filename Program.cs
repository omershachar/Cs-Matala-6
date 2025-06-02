using System;
using System.Linq;
using Assignment6;

namespace Assignment6
{
    class Program
    {
        static void Main(string[] args)
        {
            MobileDevice[] users = new MobileDevice[]
            {
                new MobileDevice("alice", "1234"),
                new MobileDevice("bob", "abcd"),
                new MobileDevice("charlie", "pass")
            };

            Console.WriteLine("Available users:");
            foreach (var user in users)
                Console.WriteLine($"Username: {user.DeviceName}, Password: {user.DevicePassword}");

            MobileDevice selectedDevice = null;
            while (selectedDevice == null)
            {
                Console.Write("Enter username to login: ");
                string inputUser = Console.ReadLine();

                selectedDevice = users.FirstOrDefault(u => u.DeviceName == inputUser);

                if (selectedDevice == null)
                    Console.WriteLine("Invalid username. Try again.");
            }

            bool loggedIn = false;
            while (!loggedIn)
            {
                Console.Write("Enter password: ");
                string inputPass = Console.ReadLine();

                try
                {
                    if (selectedDevice.Login(selectedDevice.DeviceName, inputPass))
                    {
                        Console.WriteLine("Login successful.");
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
                    return;
                }
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- MENU ---");
                Console.WriteLine("1. Add new app");
                Console.WriteLine("2. Show most popular navigation app");
                Console.WriteLine("3. Navigate to new address");
                Console.WriteLine("4. Print all installed apps");
                Console.WriteLine("5. Sort apps");
                Console.WriteLine("6. Exit");

                Console.Write("Choose: ");
                string option = Console.ReadLine();

                try
                {
                    switch (option)
                    {
                        case "1":
                            AddNewApp(selectedDevice);
                            break;
                        case "2":
                            Console.WriteLine(selectedDevice.PopularNavigationApp());
                            break;
                        case "3":
                            NavigateToNewAddress(selectedDevice);
                            break;
                        case "4":
                            Console.WriteLine(selectedDevice.ToString());
                            break;
                        case "5":
                            selectedDevice.SortApps();
                            Console.WriteLine("Apps sorted.");
                            break;
                        case "6":
                            Console.WriteLine("Bye.");
                            return;
                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
            }
        }

        static void AddNewApp(MobileDevice device)
        {
            Console.Write("Choose app type (1 = Social, 2 = Navigation): ");
            string type = Console.ReadLine();

            Console.Write("App name: ");
            string name = Console.ReadLine();

            int price;
            while (true)
            {
                Console.Write("App price: ");
                if (int.TryParse(Console.ReadLine(), out price) && price >= 0)
                    break;
                Console.WriteLine("Invalid price. Try again.");
            }

            if (type == "1")
            {
                int rating;
                while (true)
                {
                    Console.Write("Rating (1-5): ");
                    if (int.TryParse(Console.ReadLine(), out rating) && rating >= 1 && rating <= 5)
                        break;
                    Console.WriteLine("Invalid rating. Try again.");
                }

                bool isOrg;
                while (true)
                {
                    Console.Write("Is for organization? (true/false): ");
                    if (bool.TryParse(Console.ReadLine(), out isOrg))
                        break;
                    Console.WriteLine("Invalid input. Type 'true' or 'false'.");
                }

                try
                {
                    Social socialApp = new Social(name, price, rating, isOrg);
                    device.AddApp(socialApp);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error creating app: " + ex.Message);
                }
            }
            else if (type == "2")
            {
                Console.Write("Current location: ");
                string currentLoc = Console.ReadLine();

                NavigationType navType;
                while (true)
                {
                    Console.Write("Navigation type (Car, Bike, Walk): ");
                    string navInput = Console.ReadLine();
                    if (Enum.TryParse(navInput, true, out navType))
                        break;
                    Console.WriteLine("Invalid navigation type.");
                }

                try
                {
                    NavigationManager manager = new NavigationManager(currentLoc, navType);
                    Navigation navApp = new Navigation(name, price, manager);
                    device.AddApp(navApp);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error creating app: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid app type.");
            }
        }

        static void NavigateToNewAddress(MobileDevice device)
        {
            var navApps = device.Apps
                .Where(a => a is Navigation)
                .Cast<Navigation>()
                .ToList();

            if (navApps.Count == 0)
            {
                Console.WriteLine("No navigation apps installed.");
                return;
            }

            Console.WriteLine("Choose a navigation app:");
            for (int i = 0; i < navApps.Count; i++)
                Console.WriteLine($"{i + 1}. {navApps[i].AppName}");

            int index;
            if (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > navApps.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            var selectedNav = navApps[index - 1];

            Console.Write("Enter destination address: ");
            string destination = Console.ReadLine();

            try
            {
                selectedNav.Manager.AddAddress(destination);
                Console.WriteLine("Address added to recent locations.");
                selectedNav.Manager.ShowRecentLocations();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to add address: " + ex.Message);
            }
        }
    }
}
