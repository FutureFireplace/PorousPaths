using UnityEngine;
using System.Collections;

public class SplashGUI : MonoBehaviour {

	public GUISkin customSkin = null;

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
				Application.LoadLevel("Scene1");
			}
	}
		void OnGUI(){
			GUI.Box (new Rect (1, 1, 1, 1), " ");
		}
	}
		
	
	

