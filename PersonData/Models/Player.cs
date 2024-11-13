using System;

namespace PersonData.Models
{
    public class Player
    {
        public int PlayerId { get; }
        public string PlayerName { get; }
        public string Position { get; }

        public Player(int playerId, string playerName, string position)
        {
            PlayerId = playerId;
            PlayerName = playerName;
            Position = position;
        }
    }
}
