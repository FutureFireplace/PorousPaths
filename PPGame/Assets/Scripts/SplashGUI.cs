using UnityEngine;
using System.Collections;

public class SplashGUI : MonoBehaviour {

	public GUISkin customSkin = null; // allows for guiskin to be attached

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){ // will load faerdig2dageinden when space is pressed
			Application.LoadLevel("faerdig2dageinden");
			}
	}
		void OnGUI(){ // creates gui on screen
			GUI.Box (new Rect (1, 1, 1, 1), " ");
		}
	}
		
	
	

