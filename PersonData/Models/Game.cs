using System;

namespace PersonData.Models
{
    public class Game
    {
        public int GameId { get; }
        public string Location { get; }
        public bool Canceled { get; }

        //don't think I need to include time but if do here

        //public DateTime Date { get; }
        //public DateTimeOffset Time { get; }

        public Game(int gameId, string location, bool canceled)
        {
            GameId = gameId;

            Location = location;
            Canceled = canceled;
        }
    }
}
