using GXPEngine;
using TiledMapParser;
using System;
using System.Collections.Generic;


internal class SpawnPoint : GameObject
{
    private bool isUsed;
    public bool IsUsed
    {
        get
        {
            return isUsed;
        }
        set
        {
            isUsed = value;
        }
    }

    private Sprite sprite = new Sprite("checkers.png");

    public SpawnPoint(float x, float y, TiledObject obj = null)
    {
        //obj.X = x;
        //obj.Y = y;
        this.x = x;
        this.y = y;
        if (obj != null)
        {
            isUsed = obj.GetBoolProperty("isUsed", false);
        }
        sprite.alpha = 0;
        

        AddChild(sprite);
    }

    void Update()
    {
        if (Input.GetKeyUp(Key.R))
        {
            Console.WriteLine("SPAWNPOINT: "+ x + ", " + y + " state: " + isUsed);
        }

        if (isUsed)
        {
            sprite.SetColor(255, 0, 0);
        }
        else
        {
            sprite.SetColor(0,0,255);
        }
    }

}

