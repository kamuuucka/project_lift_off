using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

internal class Wall : Sprite
{
    private bool isDown = false;
    public Wall(float x, float y, TiledObject obj = null) : base("colors.png")
    {
        if (obj != null)
        {
            this.x = x;
            alpha = 0;
            width = 1366;
            isDown = obj.GetBoolProperty("isDown", false); 
            if (!isDown)
            {
                this.y = y - 64;
            }
            if (isDown)
            {
                this.y = 768 - 128;
            }
            collider.isTrigger = true;
        }   
    }
}

