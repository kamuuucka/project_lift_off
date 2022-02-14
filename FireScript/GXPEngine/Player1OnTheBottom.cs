using System;
using GXPEngine;


internal class Player1OnTheBottom : Player1
{
    private Sprite player = new Sprite("square.png");
    private float previousX = 0;
    private float previousY = 0;
    public Player1OnTheBottom(float x, float y) : base(x, y)
    {
        this.x = x;
        this.y = y;
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

    void Update()
    {
        Movement();
    }
}

