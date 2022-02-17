using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;


internal class FireMan : Player2
{
    AnimationSprite targetSpr = new AnimationSprite("P2.png", 2, 1);
    public FireMan(float x, float y, Level level) : base(x, y, level)
    {
        GoBack();
        targetSpr.SetCycle(0, 2);
        AddChild(targetSpr);
        isASprite = true;
    }

    void Update()
    {
        CharacterMovement();
        if (Input.GetKeyUp(Key.A))
        {
            targetSpr.SetCycle(1, 1);
        }
        else if (Input.GetKeyUp(Key.D))
        {
            targetSpr.SetCycle(0, 1);
        }

        targetSpr.Animate();
    }
}


