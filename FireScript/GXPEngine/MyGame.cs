using System;									// System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;                           // System.Drawing contains drawing tools such as Color definitions
using System.Collections.Generic;

public class MyGame : Game
{
	string levelName = "map.tmx";
	string mainMenu = "";
	string endScreen = "";
	private Level level;
	private EasyDraw healthUI;
	private EasyDraw pointUI;
	private EasyDraw personUI;
	public MyGame() : base(1366, 768, false)		// Create a window that's 800x600 and NOT fullscreen
	{
		LoadLevel(levelName);
	}

	// For every game object, Update is called every frame, by the engine:
	void Update()
	{
		/// HOT RELOAD
		if (Input.GetKeyDown(Key.R))
        {
			Console.WriteLine("Reloading the level " + levelName);
			LoadLevel(levelName);
        }

		if (level.GameOver())
        {
			//Exiting game, make it end screen later
			//Destroy();
        }
	}

	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();					// Create a "MyGame" and start it
	}

	private void CreateUI()
	{
		healthUI = new EasyDraw(100, 20, false);
		pointUI = new EasyDraw(100, 20, false);
		personUI = new EasyDraw(100, 20, false);
		healthUI.SetXY(0, height - 748);
		pointUI.SetXY(width - 100, height - 748);
		personUI.SetXY(width / 2, height - 748);

		LateAddChild(healthUI);
		LateAddChild(pointUI);
	}

	public void ShowHealth(int health)
	{
		if (healthUI != null)
		{
			healthUI.Text("Health: " + health, true);
		}

	}

	public void ShowPoints(int points)
	{
		if (pointUI != null)
		{
			pointUI.Text("Points: " + points, true);
		}
	}

	public void ShowPersonStats()
    {
		if ()
    }

	private void DestroyAll()
	{
		List<GameObject> children = GetChildren();
		foreach (GameObject child in children)
		{
			child.LateDestroy();
		}
	}


	void LoadLevel(string filename)
	{
		DestroyAll();
		level = new Level(filename);
		LateAddChild(level);
		CreateUI();
	}
}