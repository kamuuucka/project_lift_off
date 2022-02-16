using System;
using GXPEngine;

internal class PersonBig : Sprite
{
    private SpawnPoint spawnPoint;
    private float timer;
    private float timer2 = 20;
    private bool isPicked;
    private PlayerData playerData;
   
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
    }

    public void Grab()
    {
        LateDestroy();
        spawnPoint.IsUsed = false;
    }

    private void PersonBurning()
    {
        timer += Time.deltaTime / 1000.0f;
        if (timer > 15)
        {
            SetColor(255,0,0);
        }
        if (timer > timer2)
        {
            playerData.Lives--;
            playerData.TotalPeoplePicked++;
            LateDestroy();
        }
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

