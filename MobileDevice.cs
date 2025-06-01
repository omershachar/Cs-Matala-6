using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Assignment6.Utilities;

namespace Assignment6
{
    public class MobileDevice //: AppSystem;
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
            get => devicePassword;
            set => devicePassword = Validator.IsStringValid(value) ? value : throw new ArgumentException("Invalid device password");
        }
        public bool IsActive
        {
            get => isActive;
            set => isActive = value;
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
            set => appCount = (value >= 0) ? value : throw new ArgumentOutOfRangeException(nameof(value), "App count cannot be negative");
        }

        //Constructor
        public MobileDevice(string deviceName, string devicePassword)
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
            if (AppCount < Apps.Length)
            {
                Apps[AppCount++] = app;
            }
            else
            {
                throw new InvalidOperationException("Cannot add more apps, capacity reached.");
            }
        }
        public void RemoveApp(AppSystem app)
        {
            int index = Array.IndexOf(Apps, app);
            if (index >= 0 && index < AppCount)
            {
                for (int i = index; i < AppCount - 1; i++)
                {
                    Apps[i] = Apps[i + 1];
                }
                Apps[--AppCount] = null; // Clear the last element
            }
            else
            {
                throw new ArgumentException("App not found on the device.");
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
        public void poplarNavigationApp()
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
                Console.WriteLine("Incorrect password. Try again.");
                if (LoginAttempts >= 3)
                {
                    IsActive = false;
                    Console.WriteLine("Too many failed attempts. Device is now inactive.");
                }
            }
        }

    }
}
