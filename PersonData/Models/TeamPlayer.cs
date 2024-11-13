using System;

namespace PersonData.Models
{
    public class TeamPlayer
    {
        public int TeamPlayerId { get; }
        public int PlayerId { get; }
        public int SeasonId { get; }
        public int TeamId { get; }
        public int JerseyNumber { get; }

        public TeamPlayer(int teamPlayerId, int playerId, int seasonId, int teamId, int jerseyNumber)
        {
            TeamPlayerId = teamPlayerId;
            PlayerId = playerId;
            SeasonId = seasonId;
            TeamId = teamId;
            JerseyNumber = jerseyNumber;
        }
    }
}
