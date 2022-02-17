using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;


internal class Button : GameObject
{
    private Sprite visualButton;
    private Sprite secondVersion;
    private string filename;
    private bool isFinished;

    public Button(Sprite visualButton, Sprite secondVersion,  TiledObject obj)
    {
        this.visualButton = visualButton;
        this.secondVersion = secondVersion;
        filename = obj.GetStringProperty("load", "map_final");
        isFinished = obj.GetBoolProperty("isFinished", false);
        AddChild(secondVersion);
        secondVersion.alpha = 0;
    }

    private bool CheckHovering()
    {
        if (visualButton.HitTestPoint(Input.mouseX, Input.mouseY))
        {
            return true;
        }
        else return false;
    }

    private void SelectButton()
    {
        if (CheckHovering())
        {
            visualButton.alpha = 0;
            secondVersion.alpha = 1;
            if (Input.GetMouseButtonDown(0))
            {
                if (!isFinished)
                {
                    ((MyGame)game).LoadLevel(filename + ".tmx");
                }
                else
                {
                    ((MyGame)game).Destroy();
                }
            }
        }
        else
        {
            visualButton.alpha = 1;
            secondVersion.alpha = 0;
        }
    }

    void Update()
    {
        SelectButton();
    }
}

