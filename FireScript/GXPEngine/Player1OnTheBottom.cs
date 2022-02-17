using System;
using GXPEngine;


internal class Player1OnTheBottom : Player1
{
    private Sprite player = new Sprite("P1.png");
    private float previousX;
    public Player1OnTheBottom(float x, float y, Level level) : base(x, y, level)
    {
        this.x = x;
        this.y = y;
        previousX = x;
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

        OutOfScreenSides(previousX);
    }

    void Update()
    {
        Movement();
    }
}

