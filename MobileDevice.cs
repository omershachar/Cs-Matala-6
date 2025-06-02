using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Assignment6.Utilities;

namespace Assignment6
{
    public class MobileDevice
    {
        // Fields
        string deviceName;
        string devicePassword;
        bool isActive;
        int loginAttempts;
        AppSystem[] apps;
        int appCount;
        bool isBlocked = false;

        // Properties
        public string DeviceName
        {
            get => deviceName;
            set => deviceName = Validator.IsStringValid(value) ? value : throw new ArgumentException("Invalid device name");
        }

        public string DevicePassword
        {
            get => devicePassword;
            set => devicePassword = Validator.IsPasswordValid(value) ? value : throw new ArgumentException("Invalid device password");
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

        // Constructor
        public MobileDevice(string deviceName, string devicePassword)
        {
            DeviceName = deviceName;
            DevicePassword = devicePassword;
            IsActive = false;
            LoginAttempts = 0;
            Apps = new AppSystem[10];
            AppCount = 0;
        }

        // Methods
        public bool Login(string user, string pass)
        {
            if (isBlocked)
                throw new Exception("Device is blocked");

            if (user == DeviceName && pass == DevicePassword)
            {
                loginAttempts = 0;
                IsActive = true;
                return true;
            }

            loginAttempts++;

            if (loginAttempts % 3 == 0 && loginAttempts < 9)
            {
                Console.WriteLine("Too many attempts. Waiting 15 seconds...");
                Thread.Sleep(15000);
            }

            if (loginAttempts >= 9)
            {
                isBlocked = true;
                throw new Exception("Device permanently blocked after 9 failed attempts.");
            }

            return false;
        }

        public void AddApp(AppSystem app)
        {
            if (app == null || CompareTo(app))
                throw new ArgumentException("App cannot be null or already exists on the device.");

            if (AppCount >= Apps.Length)
                throw new InvalidOperationException("App limit reached.");

            Apps[AppCount++] = app;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Device Name: {DeviceName}");
            sb.AppendLine($"Active: {IsActive}");
            sb.AppendLine($"Login Attempts: {LoginAttempts}");
            sb.AppendLine("Installed Apps:");

            foreach (var app in Apps.Take(AppCount))
                sb.AppendLine(app.ToString());

            return sb.ToString();
        }

        public void showListAppNavigation()
        {
            Console.WriteLine("Installed Apps:");
            for (int i = 0; i < AppCount; i++)
                Console.WriteLine($"{i + 1}. {Apps[i].AppName}");

            Console.WriteLine("Select an app by number to view details or press 0 to exit.");
        }

        public string PopularNavigationApp()
        {
            string s = "Popular Apps:";
            foreach (var app in Apps.Take(AppCount).OrderByDescending(a => a.DiscountPrice).Take(5))
            {
                s += $" {app.AppName}";
            }
            return s;
        }

        public void logout()
        {
            IsActive = false;
            Console.WriteLine("You have been logged out.");
        }

        public string AppSystemPurpose()
        {
            return "This is a mobile device that can run various applications.";
        }

        public bool CompareTo(AppSystem other)
        {
            if (other == null) return false;

            for (int i = 0; i < AppCount; i++)
            {
                if (Apps[i].SpecialNum == other.SpecialNum && Apps[i].AppName == other.AppName)
                    return true;
            }

            return false;
        }
        public void SortApps()
        {
            Array.Sort(Apps, 0, AppCount, Comparer<AppSystem>.Create((a, b) => a.AppName.CompareTo(b.AppName)));
        }

    }
}