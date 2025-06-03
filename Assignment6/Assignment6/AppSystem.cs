using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment6.Utilities;

namespace Assignment6
{
    public abstract class AppSystem
    {
        //Static counter for unique IDs
        private static int counter = 1;

        //Fields
        int specialNum;
        string appName;
        int discountPrice;
        DateTime date;

        //Properties
        public int SpecialNum
        {
            get => specialNum;
            private set => specialNum = value; //no need to set externally, only incremented internally
        }

        public string AppName
        {
            get => appName;
            set => appName = Validator.IsStringValid(value) ? value : throw new ArgumentException("Invalid app name");
        }

        public int DiscountPrice
        {
            get => discountPrice;
            set => discountPrice = Validator.IsPriceValid(value) ? value : throw new ArgumentException("Invalid discount price");
        }

        public DateTime Date
        {
            get => date;
            set => date = Validator.IsDateValid(value) ? value : throw new ArgumentException("Invalid date");
        }

        //Constructor
        public AppSystem(string appName, int discountPrice)
        {
            AppName = appName;
            DiscountPrice = discountPrice;
            SpecialNum = counter++;
            Date = DateTime.Today;
        }

        //Methods
        public override string ToString()
        {
            return $"App Name: {AppName}, Special Number: {SpecialNum}, Discount Price: {DiscountPrice}, Date: {Date.ToShortDateString()}";
        }

        public abstract string AppSystemPurpose();
    }
}
