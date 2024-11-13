using System;

namespace PersonData.Models
{
    public class TeamType
    {
        public int TeamTypeId { get; }
        public int Name { get; }

        public TeamType(int teamTypeId, int name)
        {
            TeamTypeId = teamTypeId;
            Name = name;
        }
    }
}
