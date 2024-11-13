using System;

namespace PersonData.Models
{
    public class Season
    {
        public int SeasonId { get; }
        public int Year { get; }

        public Season(int seasonId, int year)
        {
            SeasonId = seasonId;
            Year = year;
        }
    }
}
