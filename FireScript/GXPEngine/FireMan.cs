using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;


internal class FireMan : Player2
{
    Sprite targetSpr = new Sprite("colors.png");
    public FireMan(float x, float y, Level level) : base(x, y, level)
    {
        //this.x = x;
        //this.y = y;
        GoBack();
        AddChild(targetSpr);
        isASprite = true;
    }

    void Update()
    {
        CharacterMovement();
    }
}


