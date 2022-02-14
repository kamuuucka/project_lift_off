using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;


internal class Ladder : Sprite
{
    private float ladderHeight;
    private float ladderY;
    public Ladder(TiledObject obj = null) : base("checkers.png")
    {
        Console.WriteLine(obj.Y);
        Console.WriteLine(obj.Height);
        ladderHeight = obj.Height;
        ladderY = obj.Y;
    }

    public float getLadderHeight()
    {
        return ladderHeight;
    }

    public float getLadderY()
    {
        return ladderY;
    }
}

