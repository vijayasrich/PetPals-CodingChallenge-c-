using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Model
{
    public class CashDonation : Donation
    {
        private static decimal donationAmount;

        public override int DonationID { get; set; }
        public override string DonorName { get; set; }
        public override decimal DonationAmount { get; set; } 
        public override DateTime DonationDate { get; set; }

        
        public CashDonation(string donorName, decimal amount, DateTime donationDate)
            : base(donorName, donationAmount) 
        {
            
            DonationAmount = donationAmount;
            DonationDate = donationDate; 
        }
        public string DonationType { get; set; } 

        public CashDonation(string donorName, decimal amount, DateTime donationDate, string donationType) : base(donorName, amount)
        {
            DonationType = donationType;
            DonationDate = donationDate;
        }

        
        public override void RecordDonation()
        {
            Console.WriteLine($"Cash Donation: {DonorName} donated {DonationAmount} on {DonationDate}");
        }
    }
}

