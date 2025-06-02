using System;
using System.Threading;
using Assignment6;

namespace Assignment6
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Predefined users
            MobileDevice[] users = new MobileDevice[]
            {
                new MobileDevice("alice", "1234"),
                new MobileDevice("bob", "abcd"),
                new MobileDevice("charlie", "pass")
            };

            Console.WriteLine("Available users:");
            foreach (var user in users)
                Console.WriteLine($"Username: {user.DeviceName}, Password: (shown for testing) {user.DevicePassword}");

            // 2. User picks a device
            MobileDevice selectedDevice = null;
            while (selectedDevice == null)
            {
                Console.Write("\nEnter username to login: ");
                string inputUser = Console.ReadLine();

                foreach (var user in users)
                {
                    if (user.DeviceName == inputUser)
                    {
                        selectedDevice = user;
                        break;
                    }
                }

                if (selectedDevice == null)
                    Console.WriteLine("Invalid username. Try again.");
            }

            // 3. Login attempt loop
            bool loggedIn = false;
            while (!loggedIn)
            {
                Console.Write("Enter password: ");
                string inputPass = Console.ReadLine();

                try
                {
                    if (selectedDevice.Login(selectedDevice.DeviceName, inputPass))
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
                    return; // Exit on permanent block
                }
            }

            // 4. Menu logic
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- MENU ---");
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
                        AddNewApp(selectedDevice);
                        break;

                    case "2":
                        try
                        {
                            string nav = selectedDevice.PopularNavigationApp();
                            Console.WriteLine(nav);
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
                        Console.WriteLine(selectedDevice.ToString());
                        break;

                    case "5":
                        selectedDevice.SortApps();
                        Console.WriteLine("Apps sorted.");
                        break;

                    case "6":
                        Console.WriteLine("Bye bye.");
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
            }
        }
        // 5. Method to add a new app
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
            else if (type == "2")
            {
                Console.Write("Current location: ");
                string currentLoc = Console.ReadLine();

                Console.Write("Choose navigation type (Car, Bike, Walk): ");
                NavigationType navType = (NavigationType)Enum.Parse(typeof(NavigationType), Console.ReadLine(), true);

                NavigationManager manager = new NavigationManager(currentLoc, navType);

                Console.Write("Number of destinations: ");
                int count = int.Parse(Console.ReadLine());

                for (int i = 0; i < count; i++)
                {
                    Console.Write($"Destination {i + 1}: ");
                    string destination = Console.ReadLine();
                    manager.AddAddress(destination);
                }

                Navigation navApp = new Navigation(name, price, manager);
                device.AddApp(navApp);
            }
            else
            {
                Console.WriteLine("Invalid app type.");
            }
        }
    }
}
