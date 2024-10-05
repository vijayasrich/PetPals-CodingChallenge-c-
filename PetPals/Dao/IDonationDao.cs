using PetPals.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Dao
{
    public interface IDonationDao
    {
        Donation GetDonationByID(int donationId);
        void AddDonation(Donation donationData);
        void UpdateDonation(Donation donationData);
        void DeleteDonation(int donationId);
        List<Donation> GetAllDonations();
        void RecordDonation(CashDonation cashDonation);
    }
}
