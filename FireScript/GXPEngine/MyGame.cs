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
	public MyGame() : base(1366, 768, false)		// Create a window that's 800x600 and NOT fullscreen
	{
		LoadLevel(levelName);
	}

	// For every game object, Update is called every frame, by the engine:
	void Update()
	{
		/// HOT RELOAD
		if (Input.GetKeyDown(Key.Q) && Input.GetKey(Key.LEFT_SHIFT))
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
	}
}