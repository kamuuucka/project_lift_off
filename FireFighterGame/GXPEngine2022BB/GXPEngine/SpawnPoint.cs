using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;
using GXPEngine;


internal class SpawnPoint : Sprite
{
    protected int number = 0;
    protected bool isUsed = false;
    private TiledObject obj;
    float fixedX;
    float fixedY;
    Sprite newSprite;
    public SpawnPoint(TiledObject obj = null) : base("colors.png")
    {
        if (obj != null)
        {
            this.obj = obj;
            number = obj.GetIntProperty("number", 0);
            isUsed = obj.GetBoolProperty("isUsed", false);
            fixedX = obj.X;
            fixedY = obj.Y;
            Console.WriteLine(fixedX + " " + fixedY);
        }
        else Console.WriteLine("Object is null");

        

    }

    protected float getX()
    {
        if (obj != null)
        {
            Console.WriteLine(fixedX);
            return fixedX;
        }
        else return 0;
    }

    protected float getY()
    {
            return fixedY;
        
    }

    void Update()
    {
        if (isUsed)
        {
            Console.WriteLine("This {0} one is used", number);
            //newSprite = new Sprite("checkers.png");
            SetColor(255, 0, 0);
        }
    }
}

