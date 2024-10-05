using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Model
{
    public class Participant
    {
        public int ParticipantID { get; set; }  
        public string ParticipantName { get; set; } 
        public string ParticipantType { get; set; }  
        public int EventID { get; set; }  
        
        public Participant(int participantID, string participantName, string participantType, int eventID)
        {
            ParticipantID = participantID;
            ParticipantName = participantName;
            ParticipantType = participantType;
            EventID = eventID;
        }

        public Participant(string? participantName, string? participantType, int eventID)
        {
            ParticipantName = participantName;
            ParticipantType = participantType;
            EventID = eventID;
        }

        // Optional ToString method for easy output
        public override string ToString()
        {
            return $"ParticipantID: {ParticipantID}, Name: {ParticipantName}, Type: {ParticipantType}, EventID: {EventID}";
        }
    }

}
