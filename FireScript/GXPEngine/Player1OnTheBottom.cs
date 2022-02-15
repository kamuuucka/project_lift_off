using System;
using GXPEngine;


internal class Player1OnTheBottom : Player1
{
    private Sprite player = new Sprite("square.png");
    private float previousX = 0;
    public Player1OnTheBottom(float x, float y, Level level) : base(x, y, level)
    {
        this.x = x;
        this.y = y;
        collider.isTrigger = true;
        AddChild(player);
    }

    private void Movement()
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
    }

    private void CheckCollisions()
    {
        GameObject[] collisions = GetCollisions();
        for (int i = 0; i < collisions.Length; i++)
        {
            if (collisions[i] is Ladder)
            {
                x = previousX;
            }
        }
    }

    void Update()
    {
        Movement();
        CheckCollisions();
    }
}

