using System;

/// <summary>
/// Player's data. Collects information about players lives and points.
/// </summary>
internal class PlayerData
{
    private const int START_LIVES = 3;
    private const int START_POINTS = 0;
    private int lives = 0;
    private int points = 0;

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
        get
        {
            return points;
        }
        set
        {
            points = value;
        }
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
    }
}