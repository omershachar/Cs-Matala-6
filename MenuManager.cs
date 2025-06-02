using System;

namespace Assignment6.Utilities
{
    public static class MenuManager
    {
        public static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("===== Mobile App Manager =====");
            Console.WriteLine("1. Add new app");
            Console.WriteLine("2. Show most popular navigation app");
            Console.WriteLine("3. Navigate to address (not implemented)");
            Console.WriteLine("4. View installed apps");
            Console.WriteLine("5. Sort apps by name");
            Console.WriteLine("6. Exit");
            Console.Write("\nChoose an option: ");
        }

        public static void Pause(string message = "Press any key to return to the menu...")
        {
            Console.WriteLine($"\n{message}");
            Console.ReadKey();
        }
    }
}