using UnityEngine;
using System.Collections;

public class SplashGUI : MonoBehaviour {

	public GUISkin customSkin = null; // allows for guiskin to be attached

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){ // will load scene1 when space is pressed
				Application.LoadLevel("Scene1");
			}
	}
		void OnGUI(){ // creates gui on screen
			GUI.Box (new Rect (1, 1, 1, 1), " ");
		}
	}
		
	
	

