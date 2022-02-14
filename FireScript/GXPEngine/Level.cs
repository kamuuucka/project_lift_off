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
    private Player2 player;
    private bool isPlayer = false;
    private float player1X;
    private float player1Y;
    private float player2X;
    private float player2Y;

    public Level(string filename)
    {
        for (int i = 0; i < 16; i++)
        {
            phList.Add(i);
        }

        loader = new TiledLoader(filename);
        loader.OnObjectCreated += OnSpriteCreated;
        StartLevel();
        SpawnFire();
        SpawnPeople();
        SpawnPlayer2();
        SpawnPlayer1();
        x = 50;
        y = 100;
    }

    private void StartLevel(bool includeImageLayers = true)
    {
        RandomNumbers(numberOfFires);

        loader.addColliders = false;
        loader.rootObject = this;
        loader.LoadImageLayers();
        loader.AddManualType("SpawnPoint");
        loader.AddManualType("SpawnPointPlayer");
        loader.rootObject = this;
        loader.LoadTileLayers(0);
        loader.addColliders = true;
        loader.LoadTileLayers(1);
        loader.LoadTileLayers(2);
        loader.LoadTileLayers(3);
        loader.autoInstance = true;
        loader.LoadObjectGroups();

        player = FindObjectOfType<Player2>();

        if (player != null)
        {
            // AddChild(new Wall(player, 64 * loader.map.Height));
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
            if (obj.Type == "SpawnPointPlayer")
            {
                SpawnPointPlayer sPlayer = new SpawnPointPlayer(obj.X, obj.Y, obj);
                LateAddChild(sPlayer);

                isPlayer = sPlayer.isPlayer1;

                if (isPlayer)
                {
                    player1X = obj.X;
                    player1Y = obj.Y;
                }
                else
                {
                    player2X = obj.X;
                    player2Y = obj.Y;
                }

                //Create players in separate method 
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
            }
            else
            {
                randomNumbers.Clear();
                RandomNumbers(1);
            }
        }
    }

    private void SpawnPlayer1()
    {
        Player1 player = new Player1(player1X, player1Y);
        Player1OnTheBottom playerOnTheBottom = new Player1OnTheBottom(player1X, loader.map.Height * 128 - 64);
        LateAddChild(player);
        LateAddChild(playerOnTheBottom);
    }

    private void SpawnPlayer2()
    {
        Player2 player = new Player2(player2X, player2Y);
        LateAddChild(player);
    }

    private void RandomNumbers(int number)
    {
        randomNumbers = phList.GetRandomItems(number);
    }
}


