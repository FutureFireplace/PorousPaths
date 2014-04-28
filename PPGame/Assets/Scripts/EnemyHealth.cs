using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public int maxHealth = 100; // defines max health
	public int curHealth = 100; // defines current health
	
	public float healthBarLenght;

	public bool showGui = false;
	
	// Use this for initialization
	void Start () {
		healthBarLenght = Screen.width / 2; 
		
	}
	
	// Update is called once per frame
	void Update () {
		AdjustCurrentHealth(0);
		StartCoroutine(Example());
	}
	
	// Creates a GUI box to display the health of the player
	void OnGUI() {
		if (showGui) {
			GUI.Box (new Rect(10, 40, healthBarLenght, 20), curHealth + "/" + maxHealth);
		}
	}

	IEnumerator Example() {
		if (curHealth == 0) {
			yield return new WaitForSeconds (2);//this will wait 5 seconds 

			Destroy (this.gameObject);
				}
	}
	public void AdjustCurrentHealth(int adj) {
		curHealth += adj;
		
		// makes sure health doesn't go below 0
		if(curHealth < 0)
			curHealth = 0;


		if (curHealth == 0) {
			Animation[] anims = GetComponentsInChildren<Animation>();
			
			foreach (Animation anim in anims) {
				anim.CrossFade("Default Take");
			}
			Example();

				}
		
		// makes sure health doesn't go above 100/maxhealth
		if(curHealth > maxHealth)
			curHealth = maxHealth;
		
		// to make sure there are no division by 0 errors
		if(maxHealth < 1)
			maxHealth = 1;
		
		healthBarLenght = (Screen.width / 2) * (curHealth / (float)maxHealth);
	}
}
