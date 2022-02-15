using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

internal class PersonBig : Sprite
{
    private SpawnPoint spawnPoint;
    private float timer;
    private float timer2 = 20;
    private bool isPicked;
    //private Player2 player;
    private PlayerData playerData;
   
    public bool IsPicked
    {
        get
        {
            return isPicked;
        }
        set
        {
            isPicked = value;
        }
    }
    public PersonBig(float x, float y, SpawnPoint spawnPoint, PlayerData playerData) : base("circle.png")
    {
        this.x = x;
        this.y = y;
        this.spawnPoint = spawnPoint;
        //this.player = player;
        this.playerData = playerData;
        collider.isTrigger = true;
        Console.WriteLine(timer2);
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
            Console.WriteLine("PERSON DIED");
            playerData.Lives--;
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

