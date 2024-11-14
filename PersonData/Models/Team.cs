using System;

namespace PersonData.Models
{
    public class Team
    {
        public int TeamId { get; }
        public string TeamName { get; }
        public string Location { get; }
        public string Mascot { get; }
        public int ConfId { get; }

        public Team(int teamId, string teamName, string location, string mascot, int confId)
        {
            TeamId = teamId;
            TeamName = teamName;
            Location = location;
            Mascot = mascot;
            ConfId = confId;
        }
    }
}
