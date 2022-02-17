using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;


internal class Target : Player1
{
    Sprite targetSpr = new Sprite("cursor_2.png");
    AnimationSprite target = new AnimationSprite("water_spritesheet.png", 3, 1);
    public Target(float x, float y, Level level) : base(x, y, level)
    {
        GoBack();
        AddChild(targetSpr);
    }

    void Update()
    {
        CharacterMovement();
    }
}

