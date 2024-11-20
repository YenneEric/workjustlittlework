using System;

public class GameSchedule
{
    public DateTime GameDate { get; set; }
    public string GameLocation { get; set; }
    public string TeamName { get; set; }
    public int TeamScore { get; set; }
    public int TeamTimeOfPossession { get; set; }
    public string OpponentName { get; set; }
    public int OpponentScore { get; set; }
    public int OpponentTimeOfPossession { get; set; }
    public string Winner { get; set; }
    public string Score => $"{TeamScore}-{OpponentScore}";

    public GameSchedule(DateTime gameDate, string gameLocation, string teamName, int teamScore,
        int teamTimeOfPossession, string opponentName, int opponentScore, int opponentTimeOfPossession, string winner)
    {
        GameDate = gameDate;
        GameLocation = gameLocation;
        TeamName = teamName;
        TeamScore = teamScore;
        TeamTimeOfPossession = teamTimeOfPossession;
        OpponentName = opponentName;
        OpponentScore = opponentScore;
        OpponentTimeOfPossession = opponentTimeOfPossession;
        Winner = winner;
    }

    public GameSchedule() { }

    public override string ToString()
    {
        return $"Date: {GameDate}, Location: {GameLocation}, Team: {TeamName}, Opponent: {OpponentName}, " +
               $"Score: {TeamScore}-{OpponentScore}, Winner: {Winner}, " +
               $"Team Time of Possession: {TeamTimeOfPossession}, Opponent Time of Possession: {OpponentTimeOfPossession}";
    }
}
