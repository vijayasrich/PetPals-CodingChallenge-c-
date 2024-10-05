using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Model
{
    public abstract class Donation
    {
        public abstract int DonationID { get; set; }
        public abstract string DonorName { get; set; }
        public abstract decimal DonationAmount { get; set; } 
        public abstract DateTime DonationDate { get; set; }

        // Constructor for base class
        protected Donation(string donorName, decimal donationAmount)
        {
            DonorName = donorName;
            DonationAmount = donationAmount;
        }

        public abstract void RecordDonation();
    }
}
