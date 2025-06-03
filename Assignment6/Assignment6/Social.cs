using System;
using Assignment6.Utilities;

namespace Assignment6
{
    public class Social : AppSystem, IApp
    {
        // static field to keep track of the number of social apps created
        private static int socialAppCount = 1;

        //Fields
        int socialSpecialNum;
        string socialName;
        int socialDiscountPrice;
        DateTime socialDate;
        int rating; // 1-5
        bool isForOrganization;

        private const double VAT_RATE = 1.13;

        //Properties
        public int SocialSpecialNum
        {
            get => socialSpecialNum;
            private set => socialSpecialNum = value;
        }

        public string SocialName
        {
            get => socialName;
            set => socialName = Validator.IsStringValid(value) ? value : throw new ArgumentException("Invalid social name");
        }

        public int SocialDiscountPrice
        {
            get => socialDiscountPrice;
            set => socialDiscountPrice = Validator.IsPriceValid(value) ? value : throw new ArgumentException("Invalid discount price");
        }

        public DateTime SocialDate
        {
            get => socialDate;
            set => socialDate = Validator.IsDateValid(value) ? value : throw new ArgumentException("Invalid date");
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

        // Constructor
        public Social(string socialName, int discountPrice, int rating, bool isForOrganization)
            : base(socialName, discountPrice) // Fix here: use the given name
        {
            SocialName = socialName;
            SocialDiscountPrice = discountPrice;
            Rating = rating;
            IsForOrganization = isForOrganization;
            SocialSpecialNum = socialAppCount++;
            SocialDate = DateTime.Today;
        }

        // Methods
        public int AddVAT()
        {
            return (int)(SocialDiscountPrice * VAT_RATE);
        }

        public override string AppSystemPurpose()
        {
            return "Far away and talking close";
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Social Name: {SocialName}, Rating: {Rating}, Is For Organization: {IsForOrganization}, Price with VAT: {AddVAT()}, Purpose: {AppSystemPurpose()}";
        }
    }
}
