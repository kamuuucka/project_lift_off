using System;
using GXPEngine;

internal class FireBig : Sprite
{
    private int lives;
    private const int START_LIVES = 10;
    private SpawnPoint spawnPoint;
    public FireBig( float x, float y, SpawnPoint spawnPoint) : base ("triangle.png")
    {
        this.x = x;
        this.y = y;
        //spawnPoint = new SpawnPoint(x, y);
        this.spawnPoint = spawnPoint;
        Reset();
    }

    public void FireDeath(int lives)
    {
        if (lives == 0)
        {
            Console.WriteLine("I DIE");
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

