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
        int specialNum = 1;
        int discountPrice = 0;
        DateTime date = DateTime.Now;

        public int SpecialNum
        {
            get => specialNum;
            set => specialNum = value;
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
