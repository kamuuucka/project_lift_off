using GXPEngine;
using TiledMapParser;
using System;
using System.Collections.Generic;


internal class SpawnPoint : GameObject
{
    int number;
    public bool isUsed;
    private bool isPlayer;
    List<int> spawnpoints = new List<int>();

    public SpawnPoint(float x, float y, TiledObject obj = null)
    {
        obj.X = x;
        obj.Y = y;
        number = obj.GetIntProperty("number", 0);
        isUsed = obj.GetBoolProperty("isUsed", false);

        //Console.WriteLine("Spawnpoint {0} spawned on x:{1} y:{2}", number, x, y);
    }

    public int GetNumber()
    {
        return number;
    }

    public bool IsUsed()
    {
        return isUsed;
    }
}

