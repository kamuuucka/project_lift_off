using System;
using GXPEngine;

internal class PersonBig : Sprite
{
    private SpawnPoint spawnPoint;
    private float timer;
    private float timer2;
    private bool isPicked;
    private PlayerData playerData;
    private Sound person_died = new Sound("npc_died.mp3");
    private Random rand = new Random();

    public bool IsPicked
    {
        get { return isPicked; }
        set { isPicked = value; }
    }

    public PersonBig(float x, float y, SpawnPoint spawnPoint, PlayerData playerData) : base("circle.png")
    {
        this.x = x;
        this.y = y;
        this.spawnPoint = spawnPoint;
        this.playerData = playerData;
        collider.isTrigger = true;
        timer2 = Utils.Random(10, 12);
        Console.WriteLine("Timer equals: " + timer2);

    }

    public void Grab()
    {
        LateDestroy();
        spawnPoint.IsUsed = false;
    }

    private void PersonBurning()
    {
        timer += Time.deltaTime / 1000.0f;
        if (timer2 - timer <= 5)
        {
            SetColor(255, 0, 0);
        }
        if (timer > timer2)
        {
            person_died.Play();
            playerData.Lives--;
            playerData.TotalPeoplePicked++;
            
            LateDestroy();
        }
    }

    private float GenerateRandomValue()
    {
        Random rand = new Random();
        double min = 20;
        double max = 30;
        double range = max - min;
        double sample = rand.NextDouble();
        double scaled = (sample * range) + min;
        float f = (float)scaled;
        return f;
    }

    void Update()
    {
        if (!isPicked)
        {
            PersonBurning();
        }
        else
        {
            Console.WriteLine("Person picked");
        }

    }
}

