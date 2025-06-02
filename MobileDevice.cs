using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Assignment6.Utilities;

namespace Assignment6
{
    public class MobileDevice : AppSystem
    {
        //Fields
        string deviceName;
        string devicePassword;
        bool isActive;
        int loginAttempts;
        AppSystem[] apps;
        int appCount;

        //Properties
        public string DeviceName
        {
            get => deviceName;
            set => deviceName = Validator.IsStringValid(value) ? value : throw new ArgumentException("Invalid device name");
        }
        public string DevicePassword
        {
            private get => devicePassword;
            set => devicePassword = Validator.IsPasswordValid(value) ? value : throw new ArgumentException("Invalid device password");
        }
        public bool IsActive
        {
            get => isActive;
            set => isActive = Validator.IsBoolValid(value) ? value : throw new ArgumentException("Invalid boolean value");
        }
        public int LoginAttempts
        {
            get => loginAttempts;
            set => loginAttempts = (value >= 0) ? value : throw new ArgumentOutOfRangeException(nameof(value), "Login attempts cannot be negative");
        }
        public AppSystem[] Apps
        {
            get => apps;
            set => apps = value ?? throw new ArgumentNullException(nameof(value), "Apps cannot be null");
        }
        public int AppCount
        {
            get => appCount;
            set => appCount = (value <= 0) ? value : throw new ArgumentOutOfRangeException(nameof(value), "App count cannot be negative");
        }

        //Constructor
        public MobileDevice(string deviceName, string devicePassword) : base(deviceName, 0)
        {
            DeviceName = deviceName;
            DevicePassword = devicePassword;
            IsActive = false;
            LoginAttempts = 0;
            Apps = new AppSystem[10]; // Initial capacity for apps
            AppCount = 0;
        }

        //Methods
        public void AddApp(AppSystem app)
        {
            if (app == null || CompareTo(app))
            {
                throw new ArgumentException("App cannot be null or already exists on the device.");
            }
            else
            {
                Apps[AppCount++] = app;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Device Name: {DeviceName}");
            sb.AppendLine($"Active: {IsActive}");
            sb.AppendLine($"Login Attempts: {LoginAttempts}");
            sb.AppendLine("Installed Apps:");
            foreach (var app in Apps.Take(AppCount))
            {
                sb.AppendLine(app.ToString());
            }
            return sb.ToString();
        }
        public void showListAppNavigation()
        {
            Console.WriteLine("Installed Apps:");
            for (int i = 0; i < AppCount; i++)
            {
                Console.WriteLine($"{i + 1}. {Apps[i].AppName}");
            }
            Console.WriteLine("Select an app by number to view details or press 0 to exit.");
        }
        public void popularNavigationApp()
        {
            Console.WriteLine("Popular Apps:");
            foreach (var app in Apps.Take(AppCount).OrderByDescending(a => a.DiscountPrice).Take(5))
            {
                Console.WriteLine(app.AppName);
            }
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }
        public void login()
        {
            Console.WriteLine("Enter device password:");
            string inputPassword = Console.ReadLine();
            if (inputPassword == DevicePassword)
            {
                IsActive = true;
                LoginAttempts = 0;
                Console.WriteLine("Login successful!");
            }
            else
            {
                LoginAttempts++;
                if (LoginAttempts >= 3)
                {
                    IsActive = false;
                    Console.WriteLine("Wait 15 seconds before trying again...");
                    System.Threading.Thread.Sleep(15000); // Wait for 15 seconds
                }
                Console.WriteLine("Incorrect password. Try again.");
            }
        }
        public void logout()
        {
            IsActive = false;
            Console.WriteLine("You have been logged out.");
        }

        public override string AppSystemPurpose()
        {
            return "This is a mobile device that can run various applications.";
        }
        public bool CompareTo(AppSystem other)
        {
            if (other == null) return false;
            for (int i = 0; i < AppCount; i++) //Going through the array
            {
                if (Apps[i].SpecialNum == other.SpecialNum && Apps[i].AppName == other.AppName) //Comparing apps names and special numbers
                {
                    return true;
                }
            }
            return false;
        }
    }
}