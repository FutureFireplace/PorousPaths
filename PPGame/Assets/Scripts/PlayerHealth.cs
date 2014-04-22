using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public int maxHealth = 100; // defines max health
	public int curHealth = 100; // defines current health

	public float healthBarLenght;

	// Use this for initialization
	void Start () {
		healthBarLenght = Screen.width / 2; 
	
	}
	
	// Update is called once per frame
	void Update () {
		AdjustCurrentHealth(0);
	}

	// Creates a GUI box to display the health of the player
	void OnGUI() {
		GUI.Box (new Rect(10, 10, healthBarLenght, 20), curHealth + "/" + maxHealth);
	}

	public void AdjustCurrentHealth(int adj) {
		curHealth += adj;

		// makes sure health doesn't go below 0
		if(curHealth < 0)
			curHealth = 0;

		// makes sure health doesn't go above 100/maxhealth
		if(curHealth > maxHealth)
			curHealth = maxHealth;

		// to make sure there are no division by 0 errors
		if(maxHealth < 1)
			maxHealth = 1;

		healthBarLenght = (Screen.width / 2) * (curHealth / (float)maxHealth);
	}
}
