using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonData.Models
{
    public class PlayerTouchdownRank
    {
        public Player Player { get; } // Reference to the Player object
        public string TeamName { get; } // Include TeamName
        public int TotalTouchdowns { get; }
        public long PositionRank { get; }

        public PlayerTouchdownRank(Player player, string teamName, int totalTouchdowns, long positionRank)
        {
            Player = player;
            TeamName = teamName;
            TotalTouchdowns = totalTouchdowns;
            PositionRank = positionRank;
        }
    }
}