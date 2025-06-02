using System;
using System.Threading;
using Assignment6;
using Assignment6.Utilities;

namespace Assignment6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "App Manager";

            MobileDevice[] devices = new MobileDevice[]
            {
            new MobileDevice("alice", "1234"),
            new MobileDevice("bob", "abcd"),
            new MobileDevice("charlie", "pass")
            };

            Console.WriteLine("Available devices:");
            foreach (var device in devices)
                Console.WriteLine($"Device Name: {device.DeviceName}, Password: (shown for testing) {device.DevicePassword}");

            MobileDevice selectedDevice = null;
            while (selectedDevice == null)
            {
                Console.Write("\nEnter device name to login: ");
                string inputName = Console.ReadLine();

                foreach (var device in devices)
                {
                    if (device.DeviceName == inputName)
                    {
                        selectedDevice = device;
                        break;
                    }
                }

                if (selectedDevice == null)
                    Console.WriteLine("Invalid device name. Try again.");
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
                    Console.WriteLine($"Login error: {ex.Message}");
                    return;
                }
            }

            // Menu loop
            while (true)
            {
                MenuManager.ShowMenu();
                string option = Console.ReadLine();

                try
                {
                    Console.Clear();

                    switch (option)
                    {
                        case "1":
                            AddNewApp(selectedDevice);
                            break;

                        case "2":
                            Console.WriteLine(selectedDevice.PopularNavigationApp());
                            break;

                        case "3":
                            Console.WriteLine("🚧 Feature not implemented yet.");
                            break;

                        case "4":
                            Console.WriteLine(selectedDevice.ToString());
                            break;

                        case "5":
                            selectedDevice.SortApps();
                            Console.WriteLine("Apps sorted by name.");
                            break;

                        case "6":
                            Console.WriteLine("Exiting... Press any key to close.");
                            Console.ReadKey();
                            return;

                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                MenuManager.Pause();
            }
        }


        static void AddNewApp(MobileDevice device)
        {
            try
            {
                Console.Write("Choose app type (1 = Social, 2 = Navigation): ");
                string type = Console.ReadLine();

                Console.Write("App name: ");
                string name = Console.ReadLine();

                Console.Write("App price: ");
                if (!int.TryParse(Console.ReadLine(), out int price))
                    throw new ArgumentException("Invalid price format.");

                if (type == "1") // Social
                {
                    Console.Write("Rating (1-5): ");
                    if (!int.TryParse(Console.ReadLine(), out int rating))
                        throw new ArgumentException("Invalid rating.");

                    Console.Write("Is for organization? (true/false): ");
                    if (!bool.TryParse(Console.ReadLine(), out bool isOrg))
                        throw new ArgumentException("Invalid input for organization flag.");

                    Social socialApp = new Social(name, price, rating, isOrg);
                    device.AddApp(socialApp);
                }
                else if (type == "2")
                {
                    Console.Write("Current location: ");
                    string currentLoc = Console.ReadLine();

                    Console.Write("Number of destinations: ");
                    if (!int.TryParse(Console.ReadLine(), out int count) || count < 0)
                        throw new ArgumentException("Invalid destination count.");

                    string[] destinations = new string[count];
                    for (int i = 0; i < count; i++)
                    {
                        Console.Write($"Destination {i + 1}: ");
                        destinations[i] = Console.ReadLine();
                    }

                    //NavigationManager manager = new NavigationManager(currentLoc, destinations);
                    //Navigation navApp = new Navigation(name, price, manager);
                    //device.AddApp(navApp);
                }
                else
                {
                    Console.WriteLine("Invalid app type.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"App creation failed: {ex.Message}");
            }
        }
    }
}