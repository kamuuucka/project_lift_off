using System;
using TiledMapParser;
using GXPEngine;

/// <summary>
/// Player. Contains everything important for the player.
/// </summary>
internal class Player2 : Sprite
{
    private float previousY = 0;
    private float previousY2 = 0;
    private float previousX = 0;
    private float startX = 0;
    public float startY = 0;
    private float speed = 128f;
    private bool canClimb = false;
    public int points = 0;
    private int peopleCollected = 0;
    public bool firstGame;
    private Level level;
    

    public Player2(float x, float y, Level level) : base("square.png")
    {

        this.x = x;
        this.y = y;
        this.level = level;
        startX = x;
        startY = y;
        previousX = startX;
        previousY = startY;
        previousY2 = startY;
        Console.WriteLine("Player2: " + x + ", " + y);
        firstGame = true;
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
                previousY2 = y;
                Console.WriteLine("PY: {0}, Y: {1}", previousY, y);
                Move(0, -speed);
                previousY = y;
            }
            else if (Input.GetKeyUp(Key.S))
            {
                previousY2 = y;
                Console.WriteLine("PY: {0}, Y: {1}", previousY, y);
                Move(0, speed);
                previousY = y;
            }
        }
        
        canClimb = false;
        CheckCollisions();
        OutOfScreenSides();
    }

    private bool OutOfScreenSides()
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
            if (collisions[i] is PersonBig)
            {
                if (peopleCollected == 0)
                {
                    ((PersonBig)collisions[i]).Grab();
                    ((PersonBig)collisions[i]).IsPicked = true;
                    peopleCollected++;
                    firstGame = false;
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
                if (points % 3 == 0 && firstGame == false)
                {
                    level.RestartLevel();
                    x = startX;
                    y = startY;
                    firstGame = true;
                }
            }
            if (collisions[i] is FireBig)
            {
                GoBack();
            }
            if (collisions[i] is Wall)
            {
                y = previousY2;
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

