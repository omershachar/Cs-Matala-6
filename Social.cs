using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment6.Utilities;

namespace Assignment6
{
    public class Social : IApp
    {
        //Fields
        int socialSpecialNum;
        string socialName;
        int discountPrice;
        DateTime date;

        int rating; //1-5
        bool isForOrganization;
        private const double VAT_RATE = 1.13; //VAT isn't 13%, but ok...

        //Properties
        public int SocialSpecialNum
        {
            get => socialSpecialNum;
            set => socialSpecialNum = value; //Removed set??
        }
        public string SocialName
        {
            get => socialName;
            set => socialName = Validator.IsStringValid(value) ? value : throw new ArgumentException("Invalid social name");
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
        public int Rating
        {
            get => rating;
            set => rating = (value >= 1 && value <= 5) ? value : throw new ArgumentOutOfRangeException(nameof(value), "Rating must be between 1 and 5");
        }
        public bool IsForOrganization
        {
            get => isForOrganization;
            set => isForOrganization = value;
        }

        //Constructors
        public Social(string socialName, int discountPrice, int rating, bool isForOrganization)
        {
            SocialName = socialName;
            DiscountPrice = discountPrice;
            Rating = rating;
            IsForOrganization = isForOrganization;
            SocialSpecialNum = 1 + this.SocialSpecialNum;
            Date = DateTime.Today;
        }

        //Methods
        public int AddVAT()
        {
            //Console.WriteLine("Adding VAT to the product price.");
            return (int)(DiscountPrice * VAT_RATE);
        }
    }
}
