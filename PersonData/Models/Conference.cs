using System;

namespace PersonData.Models
{
    public class Conference
    {
        public int ConfId { get; }
        public string ConfName { get; }

        public Conference(int confId, string confName)
        {
            ConfId = confId;
            ConfName = confName;
        }
    }
}
