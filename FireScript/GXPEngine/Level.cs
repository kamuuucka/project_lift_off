using System;
using System.Collections.Generic;
using GXPEngine;
using TiledMapParser;


internal class Level : GameObject
{
    private TiledLoader loader;
    private List<TiledObject> tiledObjects = new List<TiledObject>();
    private List<int> phList = new List<int>();
    private List<int> randomNumbers = new List<int>();
    private List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
    private int numberOfPeople = 3;
    private int numberOfFires = 5;
    private Player_LO player;

    public Level(string filename)
    {
        for (int i = 0; i < 16; i++)
        {
            phList.Add(i);
        }
        RandomNumbers(numberOfFires);

        loader = new TiledLoader(filename);
        loader.OnObjectCreated += OnSpriteCreated;
        StartLevel();
        SpawnFire();
        SpawnPeople();
        x = 50;
        y = 100;
    }

    private void StartLevel(bool includeImageLayers = true)
    {
        loader.addColliders = false;
        loader.rootObject = this;
        loader.LoadImageLayers();
        loader.AddManualType("SpawnPoint");
        loader.rootObject = this;
        loader.LoadTileLayers(0);
        loader.addColliders = true;
        loader.LoadTileLayers(1);
        loader.LoadTileLayers(2);
        loader.LoadTileLayers(3);
        loader.autoInstance = true;
        loader.LoadObjectGroups();

        player = FindObjectOfType<Player_LO>();

        if (player != null)
        {
            AddChild(new Wall(player, 64 * loader.map.Height));
        }
    }

    private void OnSpriteCreated(Sprite sprite, TiledObject obj)
    {
        if (sprite == null)
        {
            if (obj.Type == "SpawnPoint")
            {
                SpawnPoint spawn = new SpawnPoint(obj.X, obj.Y, obj);
                LateAddChild(spawn);

                tiledObjects.Add(obj);
                spawnPoints.Add(spawn);
            }
        }
       
    }

    private void SpawnFire()
    {
        for (int i = 0; i < randomNumbers.Count; i++)
        {
            if (spawnPoints[randomNumbers[i]].IsUsed() == false)
            {
                FireBig fireBig = new FireBig(tiledObjects[randomNumbers[i]].X, tiledObjects[randomNumbers[i]].Y);
                LateAddChild(fireBig);
                spawnPoints[randomNumbers[i]].isUsed = true;
            }
        } 
    }

    private void SpawnPeople()
    {
        int properlyGenerated = 0;
        randomNumbers.Clear();
        RandomNumbers(1);
        while (properlyGenerated != numberOfPeople)
        {
            if (spawnPoints[randomNumbers[0]].IsUsed() == false)
            {
                PersonBig personBig = new PersonBig(tiledObjects[randomNumbers[0]].X, tiledObjects[randomNumbers[0]].Y);
                LateAddChild(personBig);
                spawnPoints[randomNumbers[0]].isUsed = true;
                properlyGenerated++;
            } else
            {
                randomNumbers.Clear();
                RandomNumbers(1);
            }
        }
    }

    private void RandomNumbers(int number)
    {
        randomNumbers = phList.GetRandomItems(number);
    }
}


