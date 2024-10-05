using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Model
{
    public class ItemDonation : Donation
    {
        public string ItemType { get; set; }
        public override int DonationID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string DonorName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override decimal DonationAmount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override DateTime DonationDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ItemDonation(string donorName, decimal donationAmount, string itemType) : base(donorName,donationAmount)
        {
            ItemType = itemType;
        }

        public override void RecordDonation()
        {
            Console.WriteLine($"Item Donation: {DonorName} donated {ItemType} valued at {DonationAmount}");
        }
    }
}
