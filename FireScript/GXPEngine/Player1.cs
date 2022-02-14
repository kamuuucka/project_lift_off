using System;
using TiledMapParser;
using GXPEngine;

internal class Player1 : Sprite
{
    private float previousX = 0;
    private float previousY = 0;
    protected float playerSpeed = 5;
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
            Move(0, -1);
            previousY = y;
        }
        else if (Input.GetKey(Key.DOWN))
        {
            Move(0,1);
            previousY = y;
        }
    }

    void Update()
    {
        CharacterMovement();
    }
}

