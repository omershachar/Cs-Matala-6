using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment6.Utilities;

namespace Assignment6
{
    public class Navigation
    {
        //Fields
        int specialNum;
        string name;
        int discountPrice;
        DateTime date;

        //Properties
        public int SpecialNum
        {
            get => specialNum;
            set => specialNum = value;
        }

        public string Name
        {
            get => name;
            set => name = Validator.IsStringValid(value) ? value : throw new ArgumentException("Invalid name");
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

        //Constractors

        //Methods
    }
}
