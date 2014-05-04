﻿using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	private GUISkin skin;
		
		void Start()
		{
			// Load a skin for the buttons
			skin = Resources.Load("GUISkin") as GUISkin;
		}
		
		void OnGUI()
		{
			const int buttonWidth = 154;
			const int buttonHeight = 77;
			
			// Set the skin to use
			GUI.skin = skin;
			
			// Draw a button to start the game
			if (GUI.Button(
				// Center in X, 2/3 of the height in Y
				new Rect(600, 380, buttonWidth, buttonHeight),
				""
				))
			{
				// On Click, load the first level.
				Application.LoadLevel("Stage1"); // "Stage1" is the scene name
			}
		}
	}