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
    private bool isPicked = false;
    private Sound person_saved = new Sound("npc_saved.mp3");
    public int points = 0;
    private int peopleCollected = 0;
    public bool isASprite = false;
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
        firstGame = true;
        alpha = 0;
    }

    protected void CharacterMovement()
    {
        if (Input.GetKeyUp(Key.A))
        {
            previousX = x;
            Move(-speed, 0);
            Mirror(false,false);
        }
        else if (Input.GetKeyUp(Key.D))
        {
            previousX = x;
            Move(speed, 0);
            Mirror(true, false);
        }
        if (canClimb)
        {
            if (Input.GetKeyUp(Key.W))
            {
                previousY2 = y;
                Move(0, -speed);
                previousY = y;
            }
            else if (Input.GetKeyUp(Key.S))
            {
                previousY2 = y;
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
        else { return false; }
    }

    private void CheckCollisions()
    {
        GameObject[] collisions = GetCollisions();
        for (int i = 0; i < collisions.Length; i++)
        {
            if (!isASprite)
            {
                if (collisions[i] is PersonBig)
                {
                    if (peopleCollected == 0)
                    {
                        isPicked = true;
                        ((PersonBig)collisions[i]).Grab();
                        ((PersonBig)collisions[i]).IsPicked = true;
                        peopleCollected++;
                        level.SetTotalAmountOfPeople();
                        Console.WriteLine(level.GetTotalAmountOfPeople());
                        firstGame = false;
                        Console.WriteLine("PERSON RESCUED, YOU ARE CARRYING {0} PERSON", peopleCollected);
                    }
                    else
                    {
                        Console.WriteLine("YOU ARE CARRYING A PERSON ALREADY");
                    }

                }

                if (collisions[i] is Save)
                {
                    if (isPicked)
                    {
                        isPicked = false;
                        person_saved.Play();
                        points += peopleCollected;
                        level.SetTotalAmountOfPoints(peopleCollected);
                        peopleCollected = 0;
                        Console.WriteLine("TOTAL AMOUNT OF PEOPLE SAVED: {0}", points);
                    }
                    RespawnPeople();
                }
            }
            
            if (collisions[i] is Ladder)
            {
                canClimb = true;
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

    protected void GoBack()
    {
        y = previousY;
        x = previousX;
    }

    private void RespawnPeople()
    {
        if (level.GetTotalAmountOfPeople() % 3 == 0 && firstGame == false)
        {
            level.properlyGeneratedPeople = 0;
            level.RestartLevel();
            x = startX;
            y = startY;
            level.UpdatePlayer2(x, y);
            firstGame = true;
        }
    }

    private string TextToShow()
    {
        if (isPicked == false)
        {
            return "";
        }
        else
        {
            return "You are carrying a person";
        }
    }

    void Update()
    {
        CharacterMovement();
        //((MyGame)game).ShowPersonStats(isPicked, TextToShow());
        //if (isPicked)
        //{
        //    SetColor(0, 255, 0);
        //}
        //else
        //{
        //SetColor(1, 255, 0);    
        //}
    }
}

