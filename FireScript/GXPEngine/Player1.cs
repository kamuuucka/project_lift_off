using System;
using TiledMapParser;
using GXPEngine;

internal class Player1 : Sprite
{
    private float previousX = 0;
    private float previousY = 0;
    private float previousY2 = 0;
    protected float playerSpeed = 5;
    private int damage = -1;
    private int lives;

    public Player1(float x, float y) : base("colors.png")
    {
        this.x = x;
        this.y = y;
        Console.WriteLine("Player 1: " + x + " " + y);
    }

    private void CharacterMovement()
    {
        if (Input.GetKey(Key.LEFT))
        {
            previousX = x;
            Move(-playerSpeed, 0);
        }
        else if (Input.GetKey(Key.RIGHT))
        {
            previousX = x;
            Move(playerSpeed, 0);
        }

        if (Input.GetKey(Key.UP))
        {
            previousY2 = y;
            Move(0, -playerSpeed);
            previousY = y;
        }
        else if (Input.GetKey(Key.DOWN))
        {
            previousY2 = y;
            Move(0, playerSpeed);
            previousY = y;
        }

        CheckCollisions();
    }

    private void CheckCollisions()
    {
        GameObject[] collisions = GetCollisions();
        for (int i = 0; i < collisions.Length; i++)
        {
            if (collisions[i] is Ladder)
            {
                GoBack();
            }
            if (collisions[i] is Wall)
            {
                y = previousY2;
            }
            if (collisions[i] is FireBig)
            {
                ((FireBig)collisions[i]).ShootWater();
            }
        }
    }

    private void GoBack()
    {
        y = previousY;
        x = previousX;
    }

    void Update()
    {
        CharacterMovement();
    }
}

