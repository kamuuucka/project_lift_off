using System;
using GXPEngine;

internal class FireBig : AnimationSprite
{
    private int lives;
    private const int START_LIVES = 10;
    private SpawnPoint spawnPoint;
    private Player1 player1;
    public FireBig(float x, float y, SpawnPoint spawnPoint, Player1 player) : base("fire.png", 8,1)
    {
        this.x = x;
        this.y = y;
        this.spawnPoint = spawnPoint;
        if (player1 == null)
        {
            player1 = player;
        }
        SetCycle(0, 8);
            
        
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
            lives--;
            FireDeath(lives);
        }
    }

    private void Reset()
    {
        lives = START_LIVES;
    }

    void Update()
    {
        Animate(0.34f);
    }

    
}

