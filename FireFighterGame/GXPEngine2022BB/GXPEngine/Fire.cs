using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

 internal class Fire : SpawnPoint
{
    float fireX;
    float fireY;
    string filename;
    Sprite sprite;
    public Fire() : base()
    {
        filename = "checkers.png";
        sprite = new Sprite(filename);

        if (isUsed == false)
        {
            Console.WriteLine(getX() + " " + getY());
            x = getX();
            y = getY();
            isUsed = true;
        }

       // x = 64;
        //y = 64;
    }
}

