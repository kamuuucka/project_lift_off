using System;
using System.Drawing;
using GXPEngine;
using TiledMapParser;

internal class Fire : Sprite
{
    Sprite newSprite = new Sprite("checkers.png");
    public Fire(TiledObject obj = null) : base("triangle.png")
    {
        newSprite.alpha = 0;
        alpha = 1;
        LateAddChild(newSprite);
        
    }

    void Update()
    {
        if (Input.GetKeyUp(Key.R))
        {
            alpha = 0;
            newSprite.alpha = 1;
        }
    }
}

