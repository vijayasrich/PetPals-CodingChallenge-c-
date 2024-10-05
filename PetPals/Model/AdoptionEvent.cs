using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Model
{
    public class AdoptionEvent
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }

        // This property should hold the participants for the event
        public List<Participant> Participant { get; set; } = new List<Participant>();
        public DateTime Date { get;  set; }

        //public List<IAdoptable> Participant { get; set; } = new List<IAdoptable>();

        // public object Participant { get; internal set; }

        public void RegisterParticipant(IAdoptable participant)
        {
            Participant.Add((Participant)participant);
        }

        public void HostEvent()
        {
            Console.WriteLine("Adoption Event is being hosted.");
        }
    }
}
