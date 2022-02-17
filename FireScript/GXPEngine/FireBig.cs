using System;
using GXPEngine;

internal class FireBig : AnimationSprite
{
    private int lives;
    private const int START_LIVES = 40;
    private SpawnPoint spawnPoint;
    private Player1 player1;
    private Sound fire_off = new Sound("fire_off.mp3");
    private SoundChannel water;
    AnimationSprite target = new AnimationSprite("water_spritesheet.png", 3, 1);

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
        target.SetCycle(0, 3);
        target.alpha = 0;
        target.scale = 2;
        AddChild(target);
    }

    public void FireDeath(int lives)
    {
        if (lives == 0)
        {
            fire_off.Play();
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
            PlaySound();
            Console.WriteLine(lives);
            FireDeath(lives);
            this.alpha = 0;
            target.alpha = 1;
        }
        else
        {
            if (water != null)
            {
                water.Stop();
            }
            this.alpha = 1;
            target.alpha = 0;
        }
    }

    private void PlaySound()
    {
        water = new Sound("water.mp3", false, true).Play();
        water.Volume = 0.05f;
    }

    private void Reset()
    {
        lives = START_LIVES;
    }

    void Update()
    {
        Animate(0.34f);
        target.Animate(0.34f);
        
    }

    
}

