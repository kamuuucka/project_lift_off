using GXPEngine;
using TiledMapParser;


internal class Person : Sprite
{
    public Person(TiledObject obj = null) : base("circle.png")
    {
        if (obj != null)
        {
            width = 40;
            height = 40;
        }
    }

    public void Grab()
    {
        LateDestroy();
    }


}

