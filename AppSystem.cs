using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6.Utilities
{
    public abstract class AppSystem
    {
        //Fields
        int specialNum;
        string appName;
        int discountPrice;
        DateTime date;

        //Properties
        public int SpecialNum
        {
            get => specialNum;
            set => specialNum = value; //Removed set??
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

        //Constructors
        public AppSystem(string appName, int discountPrice)
        {
            AppName = appName;
            DiscountPrice = discountPrice;
            SpecialNum = 1 + this.SpecialNum;
            Date = DateTime.Today;
        }

        //Methods
        public override string ToString()
        {
            return $"App Name: {AppName}, Special Number: {SpecialNum}, Discount Price: {DiscountPrice}, Date: {Date.ToShortDateString()}";
        }

        public abstract string AppSystemPurpose(); //That's good enough??

        public interface IComparable //Like this??
        {
            bool CompareTo(AppSystem other);
        }
    }
}
