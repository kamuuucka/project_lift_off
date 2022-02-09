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
    private bool canClimb = false;
    private int points = 0;
    private int peopleCollected = 0;

    public Player_LO(TiledObject obj = null) : base("square.png")
    {
        if (obj != null)
        {
            startX = obj.X + 32;
            startY = obj.Y + 32;
            previousX = startX;
            previousY = startY;
            Console.WriteLine("Player spawned: " + startX + ", " + startY);
        }
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
        if (canClimb)
        {
            if (Input.GetKeyUp(Key.W))
            {
                
                Console.WriteLine("PY: {0}, Y: {1}", previousY, y);
                Move(0, -speed);
                previousY = y;
            }
            else if (Input.GetKeyUp(Key.S))
            {
                
                Console.WriteLine("PY: {0}, Y: {1}", previousY, y);
                Move(0, speed);
                previousY = y;
            }
        }
        
        canClimb = false;
        CheckCollisions();
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

    private void CheckCollisions()
    {
        GameObject[] collisions = GetCollisions();
        for (int i = 0; i < collisions.Length; i++)
        {
            if (collisions[i] is Person)
            {
                if (peopleCollected == 0)
                {
                    ((Person)collisions[i]).Grab();
                    peopleCollected++;
                    Console.WriteLine("PERSON RESCUED, YOU ARE CARRYING {0} PERSON", peopleCollected);
                }
                else
                {
                    Console.WriteLine("YOU ARE CARRYING A PERSON ALREADY");
                }
                
            }
            if (collisions[i] is Ladder)
            {
                canClimb = true;
            }
            if (collisions[i] is Save)
            {
                points += peopleCollected;
                peopleCollected = 0;
                Console.WriteLine("TOTAL AMOUNT OF PEOPLE SAVED: {0}", points);
            }
            if (collisions[i] is Fire)
            {
                GoBack();
            }
        }
    }

    void GoBack()
    {
        y = previousY;
        x = previousX;
    }


    void Update()
    {
        CharacterMovement();
    }
}

