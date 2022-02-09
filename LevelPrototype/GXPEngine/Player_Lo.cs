using System;
using TiledMapParser;
using GXPEngine;

/// <summary>
/// Player. Contains everything important for the player.
/// </summary>
internal class Player_LO : Sprite
{
    private float previousY = 0;
    private float previousX = 0;
    public float startX = 0;
    public float startY = 0;
    private float speed = 128f;

    public Player_LO(TiledObject obj = null) : base("square.png")
    {
 
    }

    private void CharacterMovement()
    {
        if (Input.GetKeyUp(Key.A))
        {
            previousX = x;
            Move(-speed, 0);
        }
        else if (Input.GetKeyUp(Key.D))
        {
            previousX = x;
            Move(speed, 0);
        }
        else if (Input.GetKeyUp(Key.W))
        {
            previousY = y;
            Move(0, -speed);
        }
        else if (Input.GetKeyUp(Key.S))
        {
            previousY = y;
            Move(0, speed);
        }

        OutOfScreen();
    }

    private bool OutOfScreen()
    {
        if (x < 0 || x > 1280)
        {
            x = previousX;
            return true;
        }
        else
        {
            return false;
        }


    }


    void Update()
    {
        CharacterMovement();
    }
}

