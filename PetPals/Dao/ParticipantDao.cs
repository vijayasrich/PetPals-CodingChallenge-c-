using PetPals.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Dao
{
    public class ParticipantDao
    {
        private List<Participant> participants = new List<Participant>();

        public void AddParticipant(Participant participant)
        {
            participants.Add(participant);
        }

        public void RemoveParticipant(int participantID)
        {
            var participant = participants.FirstOrDefault(p => p.ParticipantID == participantID);
            if (participant != null)
            {
                participants.Remove(participant);
            }
        }

        public Participant GetParticipantByID(int participantID)
        {
            return participants.FirstOrDefault(p => p.ParticipantID == participantID);
        }

        public List<Participant> GetAllParticipants()
        {
            return participants;
        }
    }
}
