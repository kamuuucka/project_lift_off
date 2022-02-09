using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;


internal class Level : GameObject
{
    TiledLoader loader;
    Random rand = new Random();
    public Level(string filename)
    {
        loader = new TiledLoader("map_prototype.tmx");
        StartLevel();
    }
    private void StartLevel(bool includeImageLayers = true)
    {
        loader.addColliders = false;
        loader.rootObject = game;
        loader.LoadImageLayers();
        loader.rootObject = this;
        loader.LoadTileLayers(0);
        loader.addColliders = true;
        loader.LoadTileLayers(1);
        loader.LoadTileLayers(2);
        loader.LoadTileLayers(3);
        loader.autoInstance = true;
        loader.LoadObjectGroups();

        for (int i = 0; i < 2; i++)
        {
            LateAddChild(new Fire(rand.Next(0, 1280), rand.Next(0, 768)));
        }
    }
}


