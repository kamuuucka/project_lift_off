using System;
using TiledMapParser;
using GXPEngine;

internal class Player1 : Sprite
{
    private float previousX;
    private float previousY ;
    private float previousY2 = 0;
    protected float playerSpeed = 5;
    private Level level;
    private bool isEmpty = false;
    

    public Player1(float x, float y, Level level) : base("water_spritesheet.png")
    {
        this.x = x;
        this.y = y;
        this.level = level;
        previousX = x;
        previousY = y;
        alpha = 0;
    }

    protected void CharacterMovement()
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
        OutOfScreenSides(previousX);
    }

    private void CheckCollisions()
    {
        GameObject[] collisions = GetCollisions();
        for (int i = 0; i < collisions.Length; i++)
        {
            if (collisions[i] is Wall)
            {
                y = previousY2;
            }
            if (collisions[i] is FireBig)
            {
                level.UpdatePlayer1(previousX, previousY);
                ((FireBig)collisions[i]).ShootWater();
            }
        }
    }

    protected bool OutOfScreenSides(float previousX)
    {
        if (x < 120 || x > 1090)
        {

            x = previousX;
            return true;
        }
        else { return false; }
    }

    

    protected void GoBack()
    {
        y = previousY;
        x = previousX;
    }

    public void canBeEmpty(bool canBe)
    {
        isEmpty = canBe;
        level.properlyGeneratedFire--;
    }

    void Update()
    {
        CharacterMovement();
    }
}

