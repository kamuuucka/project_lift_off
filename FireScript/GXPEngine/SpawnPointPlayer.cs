using GXPEngine;
using TiledMapParser;
using System;
using System.Collections.Generic;


internal class SpawnPointPlayer : GameObject
{
    public bool isPlayer1 = false;
    public SpawnPointPlayer(float x, float y, TiledObject obj = null)
    {
        obj.X = x;
        obj.Y = y;
        isPlayer1 = obj.GetBoolProperty("isPlayer1", false);
    }

    public float getX()
    {
        return x;
    }

    public float getY()
    {
        return y;
    }

}

