using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

internal class FireBig : Sprite
{
    //public int Lives
    //{
    //    get
    //    {
    //        return lives;
    //    }
    //    set
    //    {
    //        lives = value;
    //        if (lives < 0)
    //        {
    //            lives = 0;
    //        }
    //    }
    //}

    public FireBig( float x, float y) : base ("triangle.png")
    {
        this.x = x;
        this.y = y;
        Reset();
    }

    public void FireDeath(int lives)
    {
        if (lives == 0)
        {
            Console.WriteLine("I DIE");
            LateDestroy();
        }
    }

    private int lives;
    private const int START_LIVES = 10;

    public void ShootWater()
    {
        if (Input.GetKey(Key.SPACE))
        {
            SetColor(0, 255, 0);
            Console.WriteLine("Shooting water");
            lives--;
        }
        else
        {
            SetColor(0, 0, 0);
        }

    }

    private void Reset()
    {
        lives = START_LIVES;
    }

    void Update()
    {
        //ShootWater();
        FireDeath(lives);
    }

    
}

