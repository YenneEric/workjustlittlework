using System;

namespace PersonData.Models
{
    public class TeamType
    {
        public int TeamTypeId { get; }
        public string Name { get; }

        public TeamType(int teamTypeId, string name)
        {
            TeamTypeId = teamTypeId;
            Name = name;
        }
    }
}
