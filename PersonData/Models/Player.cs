public class Player
{
    public int PlayerId { get; }
    public string PlayerName { get; }
    public string Position { get; }
    public string TeamName { get; }
    public int TotalTouchdowns { get; }
    public long PositionRank { get; } // Change to long

    public Player(int playerId, string playerName, string position, string teamName, int totalTouchdowns, long positionRank)
    {
        PlayerId = playerId;
        PlayerName = playerName;
        Position = position;
        TeamName = teamName;
        TotalTouchdowns = totalTouchdowns;
        PositionRank = positionRank;
    }
}
