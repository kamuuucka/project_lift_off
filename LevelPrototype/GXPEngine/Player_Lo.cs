using System;
using TiledMapParser;
using GXPEngine;

/// <summary>
/// Player. Contains everything important for the player.
/// </summary>
internal class Player_LO : Sprite
{
    private int damage = 1;
    private float previousY = 0;
    private float previousX = 0;
    public float startX = 0;
    public float startY = 0;
    private float speed = 128f;
    private bool logAttached = false;
    public bool isDead = false;
    private bool isFinished = false;

    public Player_LO(TiledObject obj = null) : base("square.png")
    {
        //if (obj != null)
        //{
        //    startX = obj.X + 20;
        //    startY = obj.Y + 20;
        //    previousX = startX;
        //    previousY = startY;
        //    Console.WriteLine("Player spawned: " + startX + ", " + startY);
        //}
    }

    /// <summary>
    /// Player can move with the help of WASD keys.
    /// Handles the animation, side blocking and collision.
    /// Detaches player from the logs
    /// </summary>
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

    /// <summary>
    /// Prevents player from jumping out of screen on the sides.
    /// Checks if player got out of the screen with help of the log.
    /// </summary>
    /// <returns>
    /// 1 if player is out of the screen
    /// 0 if player is still on the screen
    /// </returns>
    private bool OutOfScreen()
    {
        if (x < 0 || x > 1280)
        {
            x = previousX;
            return true;
            if (y < 0 || y > 768)
            {
                y = previousY;
                return true;
            }
            else
            {
                return false;
            }
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

