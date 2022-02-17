using System;
using GXPEngine;

internal class PersonBig : AnimationSprite
{
    private SpawnPoint spawnPoint;
    private float timer;
    private float timer2;
    private bool isPicked;
    private PlayerData playerData;
    private Sound person_died = new Sound("npc_died.mp3");

    public bool IsPicked
    {
        get { return isPicked; }
        set { isPicked = value; }
    }

    public PersonBig(float x, float y, SpawnPoint spawnPoint, PlayerData playerData) : base("NPC_new.png", 2, 1)
    {
        this.x = x;
        this.y = y;
        this.spawnPoint = spawnPoint;
        this.playerData = playerData;
        collider.isTrigger = true;
        timer2 = Utils.Random(15, 30);
        Console.WriteLine("Timer equals: " + timer2);
        SetCycle(0, 2);
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
        Animate(0.05f);
    }
}

