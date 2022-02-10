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
    public Level(string filename)
    {
        loader = new TiledLoader(filename);
        StartLevel();
        x = 50;
        y = 100;
    }
    private void StartLevel(bool includeImageLayers = true)
    {


        loader.addColliders = false;
        loader.rootObject = this;
        loader.LoadImageLayers();
        loader.rootObject = this;
        loader.LoadTileLayers(0);
        loader.addColliders = true;
        loader.LoadTileLayers(1);
        loader.LoadTileLayers(2);
        loader.LoadTileLayers(3);
        loader.autoInstance = true;
        loader.LoadObjectGroups();


    }
}


