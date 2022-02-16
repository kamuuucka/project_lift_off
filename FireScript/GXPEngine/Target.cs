using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;


internal class Target : Player1
{
    Sprite targetSpr = new Sprite("square.png");
    public Target(float x, float y, Level level) : base(x, y, level)
    {
        //this.x = x;
        //this.y = y;
        GoBack();
        AddChild(targetSpr);
    }

    void Update()
    {
        CharacterMovement();
    }
}

