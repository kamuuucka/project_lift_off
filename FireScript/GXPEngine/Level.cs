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
    private List<FireBig> fires = new List<FireBig>();
    private int numberOfPeople = 3;
    private int numberOfFires = 5;
    private float player1X;
    private float player1Y;
    private float player2X;
    private float player2Y;
    private Player2 player2;
    private Player1 player1;
    private PlayerData playerData = new PlayerData();
    public int properlyGeneratedFire = 0;
    private bool gameLoadedFirstTime = true;

    public Level(string filename)
    {
        for (int i = 0; i < 16; i++)
        {
            phList.Add(i);
        }

        loader = new TiledLoader(filename);
        loader.OnObjectCreated += OnSpriteCreated;
        StartLevel();
        
        SpawnPeople();
        SpawnPlayer2();
        SpawnPlayer1();
        SpawnFire();
        x = 50;
        y = 100;
        gameLoadedFirstTime = false;
    }

    private void StartLevel(bool includeImageLayers = true)
    {
        loader.addColliders = false;
        loader.rootObject = this;
        loader.LoadImageLayers();
        loader.AddManualType("SpawnPoint");
        loader.AddManualType("SpawnPointPlayer");
        loader.AddManualType("Wall");
        loader.rootObject = this;
        loader.LoadTileLayers(0);
        loader.addColliders = true;
        loader.LoadTileLayers(1);
        loader.LoadTileLayers(2);
        loader.LoadTileLayers(3);
        loader.autoInstance = true;
        loader.LoadObjectGroups();
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

                if (sPlayer.isPlayer1)
                {
                    player1X = obj.X;
                    player1Y = obj.Y;
                }
                else
                {
                    player2X = obj.X;
                    player2Y = obj.Y;
                }
            }
            if(obj.Type == "Wall")
            {
                Wall wall = new Wall(obj.X, obj.Y, obj);
                LateAddChild(wall);
            }
        }

    }

    private void SpawnFire()
    {
       //RandomNumbers(numberOfFires);

        //if (gameLoadedFirstTime)
        //{
        //    for (int i = 0; i < randomNumbers.Count; i++)
        //    {
        //        if (!spawnPoints[randomNumbers[i]].IsUsed)
        //        {
        //            FireBig fireBig = new FireBig(tiledObjects[randomNumbers[i]].X, tiledObjects[randomNumbers[i]].Y, spawnPoints[randomNumbers[i]]);
        //            LateAddChild(fireBig);
        //            fires.Add(fireBig);
        //            spawnPoints[randomNumbers[i]].IsUsed = true;
        //        }
        //    }
        //}

        int properlyGenerated = 0;
        randomNumbers.Clear();
        RandomNumbers(1);
        while (properlyGeneratedFire != numberOfFires)
        {
            if (!spawnPoints[randomNumbers[0]].IsUsed)
            {
                FireBig fireBig = new FireBig(tiledObjects[randomNumbers[0]].X, tiledObjects[randomNumbers[0]].Y, spawnPoints[randomNumbers[0]], player1);
                LateAddChild(fireBig);
                spawnPoints[randomNumbers[0]].IsUsed = true;
                properlyGeneratedFire++;
            }
            else
            {
                randomNumbers.Clear();
                RandomNumbers(1);
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
            if (!spawnPoints[randomNumbers[0]].IsUsed)
            {
                PersonBig personBig = new PersonBig(tiledObjects[randomNumbers[0]].X, tiledObjects[randomNumbers[0]].Y, spawnPoints[randomNumbers[0]], playerData);
                LateAddChild(personBig);
                spawnPoints[randomNumbers[0]].IsUsed = true;
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
        player1 = new Player1(player1X, player1Y, this);
        Player1OnTheBottom playerOnTheBottom = new Player1OnTheBottom(player1X, loader.map.Height * 128 - 64, this);
        LateAddChild(player1);
        LateAddChild(playerOnTheBottom);
    }

    private void SpawnPlayer2()
    {
        player2 = new Player2(player2X, player2Y, this);
        LateAddChild(player2);
    }

    public void RestartLevel()
    {
        SpawnPeople();
    }

    private void RandomNumbers(int number)
    {
        randomNumbers = phList.GetRandomItems(number);
    }

    public bool GameOver()
    {
        if (playerData.Lives == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Update()
    {
        //Console.WriteLine(playerData.Lives);
        SpawnFire();
    }
}


