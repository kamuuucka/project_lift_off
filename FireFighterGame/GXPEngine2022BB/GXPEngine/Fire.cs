using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

 internal class Fire : Sprite
{
    float fireX;
    float fireY;
    public Fire(float x, float y) : base("colors.png")
    {
        //SetScaleXY(64, 64);
        this.fireX = x;
        this.fireY = y;
        collider.isTrigger = true;
        SetXY(fireX, fireY);
    }
}

