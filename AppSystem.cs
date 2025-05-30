using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6.Utilities
{
    public abstract class AppSystem
    {
        int specialNum = 1;
        string appName = "App System";
        int discountPrice = 0;
        DateTime date = DateTime.Now;

        public int SpecialNum
        {
            get => specialNum;
            set => specialNum = value;
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


    }
}
