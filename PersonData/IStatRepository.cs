﻿using PersonData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonData
{
    public interface IStatRepository
    {

        IReadOnlyList<PlayerTouchdownRank> FetchTouchdownPlayer(string pos, int year);

        IReadOnlyList<GameSchedule> FetchGameSchedule(string teamName, int year);

        IReadOnlyList<GamePlayerStats> FetchPlayerStatsByGameAndTeam(int gameId, string teamName, int? playerId = null);

    }
}
