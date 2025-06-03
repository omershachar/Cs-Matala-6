using System;
using Assignment6.Utilities;

namespace Assignment6
{
    public class Navigation : AppSystem, IApp
    {
        // Static counter for unique special numbers
        private static int navigationAppCount = 1;

        // Fields
        int navigationSpecialNum;
        string navigationName;
        int navigationDiscountPrice;
        DateTime navigationDate;
        NavigationManager manager;

        private const double VAT_RATE = 1.13;

        // Properties
        public int NavigationSpecialNum
        {
            get => navigationSpecialNum;
            private set => navigationSpecialNum = value;
        }

        public string NavigationName
        {
            get => navigationName;
            set => navigationName = Validator.IsStringValid(value) ? value : throw new ArgumentException("Invalid navigation name");
        }

        public int NavigationDiscountPrice
        {
            get => navigationDiscountPrice;
            set => navigationDiscountPrice = Validator.IsPriceValid(value) ? value : throw new ArgumentException("Invalid discount price");
        }

        public DateTime NavigationDate
        {
            get => navigationDate;
            set => navigationDate = Validator.IsDateValid(value) ? value : throw new ArgumentException("Invalid date");
        }

        public NavigationManager Manager
        {
            get => manager;
            set => manager = value ?? throw new ArgumentNullException(nameof(value), "Manager cannot be null");
        }

        // Constructor
        public Navigation(string name, int price, NavigationManager navManager)
            : base(name, price)
        {
            NavigationName = name;
            NavigationDiscountPrice = price;
            Manager = navManager;
            NavigationSpecialNum = navigationAppCount++;
            NavigationDate = DateTime.Today;
        }

        // Methods
        public int AddVAT()
        {
            return (int)(NavigationDiscountPrice * VAT_RATE);
        }

        public override string AppSystemPurpose()
        {
            return "Guiding users to their destinations.";
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Navigation Name: {NavigationName}, {Manager}, Price with VAT: {AddVAT()}, Purpose: {AppSystemPurpose()}";
        }
    }
}
