using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    public enum NavigationType
    {
        Car,
        Bike,
        Walk
    }
    public class NavigationManager
    {
        //Fields
        string address;
        string[] addressesArr;
        int addressCount;
        NavigationType type;

        //Properties
        public string Address
        {
            get => address;
            set => address = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("Invalid address");
        }

        public string[] AddressesArr
        {
            get => addressesArr;
            set => addressesArr = value ?? throw new ArgumentNullException(nameof(value), "Addresses array cannot be null");
        }

        public int AddressCount
        {
            get => addressCount;
            set => addressCount = value >= 0 ? value : throw new ArgumentOutOfRangeException(nameof(value), "Address count cannot be negative");
        }

        public NavigationType Type
        {
            get => type;
            set => type = Enum.IsDefined(typeof(NavigationType), value) ? value : throw new ArgumentException("Invalid navigation type");
        }

        //Constructors
        public NavigationManager(string address, NavigationType type)
        {
            Address = address;
            Type = type;
            AddressesArr = new string[0];
            AddressCount = 0;
        }

        //Methods
        public override string ToString()
        {
            return $"Address: {Address}, Type: {Type}, Address Count: {AddressCount}, Addresses: [{string.Join(", ", AddressesArr)}]";
        }

        public void ShowRecentLocations()
        {
            if (AddressesArr.Length == 0)
            {
                Console.WriteLine("No recent locations available.");
                return;
            }
            Console.WriteLine("Recent Locations:");
            foreach (var addr in AddressesArr)
            {
                Console.WriteLine($"- {addr}");
            }
        }
        public void AddAddress(string newAddress)
        {
            if (string.IsNullOrWhiteSpace(newAddress))
            {
                throw new ArgumentException("Invalid address");
            }
            Array.Resize(ref addressesArr, addressesArr.Length + 1);
            addressesArr[addressesArr.Length - 1] = newAddress;
            AddressCount++;
        }
    }
}
