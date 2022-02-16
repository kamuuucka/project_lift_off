using System;

/// <summary>
/// Player's data. Collects information about players lives and points.
/// </summary>
internal class PlayerData
{
    private const int START_LIVES = 3;
    private const int START_POINTS = 0;
    private const int TOTAL_PEOPLE_PICKED = 0;
    private int lives = 0;
    private int points = 0;
    private int totalPeoplePicked = 0;
    private float player1X;
    private float player1Y;
    private float player2X;
    private float player2Y;

    public int Lives
    {
        get
        {
            return lives;
        }
        set
        {
            lives = value;
            if (lives < 0)
            {
                lives = 0;
            }
        }
    }

    public int Points
    {
        get { return points; }
        set { points = value; }
    }

    public float Player1X
    {
        get { return player1X; }
        set { player1X = value; }
    }

    public float Player1Y
    {
        get { return player1Y; }
        set { player1Y = value; }
    }

    public float Player2X
    {
        get { return player2X; }
        set { player2X = value; }
    }

    public float Player2Y
    {
        get { return player2Y; }
        set { player2Y = value; }
    }

    public int TotalPeoplePicked
    {
        get { return totalPeoplePicked; }
        set { totalPeoplePicked = value; }
    }

    public PlayerData()
    {
        Reset();
    }

    /// <summary>
    /// Resets player's data to the state at the beginning of the game
    /// </summary>
    private void Reset()
    {
        lives = START_LIVES;
        points = START_POINTS;
        totalPeoplePicked = TOTAL_PEOPLE_PICKED;
    }
}