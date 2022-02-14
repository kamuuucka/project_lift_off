using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

internal class FireData
{
    private int lives;
    private const int START_LIVES = 10;
    public int Lives
    {
        get
        {
            return lives;
        }
        set
        {
            lives = value;
            if (lives < 0)
            {
                lives = 0;
            }
        }
    }

    public FireData()
    {
        Reset();
    }

    private void Reset()
    {
        lives = START_LIVES;
    }
}

