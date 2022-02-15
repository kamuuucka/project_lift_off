using System;
using GXPEngine;

internal class FireBig : Sprite
{
    private int lives;
    private const int START_LIVES = 10;
    private SpawnPoint spawnPoint;
    private Player1 player1;
    public FireBig( float x, float y, SpawnPoint spawnPoint, Player1 player) : base ("triangle.png")
    {
        this.x = x;
        this.y = y;
        this.spawnPoint = spawnPoint;
        if (player1 != null)
        {
            player1 = player;
        }
        Reset();
    }

    public void FireDeath(int lives)
    {
        if (lives == 0)
        {
            Console.WriteLine("I DIE");
            player1.canBeEmpty(true);
            LateDestroy();
            spawnPoint.IsUsed = false;
            
        }
    }

    public void ShootWater()
    {
        if (Input.GetKey(Key.SPACE))
        {
            SetColor(0, 255, 0);
            Console.WriteLine("Shooting water");
            lives--;
        }
        else
        {
            SetColor(0, 0, 0);
        }

    }

    private void Reset()
    {
        lives = START_LIVES;
    }

    void Update()
    {
        FireDeath(lives);
    }

    
}

