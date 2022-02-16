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
    private int numberOfFires = 10;
    private Player2 player2;
    private Player1 player1;
    private PlayerData playerData = new PlayerData();
    private Target target;
    private FireMan fireman;
    public int properlyGeneratedFire = 0;
    public int properlyGeneratedPeople = 0;

    public Level(string filename)
    {
        for (int i = 0; i < 29; i++)
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
        AddPlayer1Visuals();
        AddPlayer2Visuals();
        x = 50;
        y = 100;
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
                    playerData.Player1X = obj.X;
                    playerData.Player1Y = obj.Y;
                }
                else
                {
                    playerData.Player2X = obj.X;
                    playerData.Player2Y = obj.Y;
                }
            }
            if (obj.Type == "Wall")
            {
                Wall wall = new Wall(obj.X, obj.Y, obj);
                LateAddChild(wall);
            }
        }

    }

    private void SpawnFire()
    {
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
                AddPlayer1Visuals();
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
        randomNumbers.Clear();
        RandomNumbers(1);
        for (int i = 0; i < numberOfPeople;)
        {
            if (!spawnPoints[randomNumbers[0]].IsUsed)
            {
                PersonBig personBig = new PersonBig(tiledObjects[randomNumbers[0]].X, tiledObjects[randomNumbers[0]].Y, spawnPoints[randomNumbers[0]], playerData);
                LateAddChild(personBig);
                spawnPoints[randomNumbers[0]].IsUsed = true;
                properlyGeneratedPeople++;
                AddPlayer2Visuals();
                AddPlayer1Visuals();
                i++;
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
        player1 = new Player1(playerData.Player1X, playerData.Player1Y, this);
        Player1OnTheBottom playerOnTheBottom = new Player1OnTheBottom(playerData.Player1X, loader.map.Height * 128 - 64, this);
        LateAddChild(playerOnTheBottom);
        LateAddChild(player1);
    }

    private void SpawnPlayer2()
    {
        player2 = new Player2(playerData.Player2X, playerData.Player2Y, this);
        LateAddChild(player2);
    }

    private void AddPlayer1Visuals()
    {
        if (target != null)
        {
            target.LateDestroy();
            Console.WriteLine(playerData.Player1X);
        }

        target = new Target(playerData.Player1X, playerData.Player1Y, this);
        LateAddChild(target);
    }

    private void AddPlayer2Visuals()
    {
        if (fireman != null)
        {
            fireman.LateDestroy();
        }
        fireman = new FireMan(playerData.Player2X, playerData.Player2Y, this);
        LateAddChild(fireman);
    }

    public void UpdatePlayer1(float playerx, float playery)
    {
        playerData.Player1X = playerx;
        playerData.Player1Y = playery;
    }

    public void UpdatePlayer2(float playerx, float playery)
    {
        playerData.Player2X = playerx;
        playerData.Player2Y = playery;
    }

    public int GetTotalAmountOfPeople()
    {
        return playerData.TotalPeoplePicked;
    }

    public void SetTotalAmountOfPeople()
    {
        playerData.TotalPeoplePicked++;
    }

    public void SetTotalAmountOfPoints(int amount)
    {
        playerData.Points += amount;
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
        ((MyGame)game).ShowHealth(playerData.Lives);
        ((MyGame)game).ShowPoints(playerData.Points);
    }
}


