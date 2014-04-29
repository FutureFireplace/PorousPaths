using UnityEngine;
using System.Collections;

public class EndScreen : MonoBehaviour {

	public GUISkin customSkin = null; // allows for a guiskin to be attached

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)) // will load Splash scene when space is pressed
				Application.LoadLevel("Splash");
			
		if(Input.GetKey("escape"))  // will cause application to quit
				Application.Quit();
	}
		void OnGUI(){ // creates a GUI
			GUI.Box (new Rect (1, 1, 1, 1), " ");
		}
	}
		
	
	



