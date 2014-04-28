using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	public GameObject target;

	public float attackTimer;
	public float attackCoolDown;

	// Use this for initialization
	void Start () {
		attackTimer = 0;
		attackCoolDown = 1.5f; // sets cooldown on attack so attack can't be spammed
	}
	
	// Update is called once per frame
	public void setTarget(GameObject newTarget){

		if (target != null) {
			EnemyHealth eh = (EnemyHealth)target.GetComponent ("EnemyHealth");
			eh.showGui = false;
		}

		EnemyHealth ehNew = (EnemyHealth)newTarget.GetComponent ("EnemyHealth");
		ehNew.showGui = true;

		target = newTarget;
	}

	void Update () {
		if(attackTimer > 0)
			attackTimer -= Time.deltaTime;

		if(attackTimer < 0)
			attackTimer = 0; 
		
		if(Input.GetKeyUp(KeyCode.Q)) { //takes Q as a key input. Initiate attack when the button is released
			if(attackTimer == 0) { // allows player to attack if attacktimer is 0
				Attack();
				attackTimer = attackCoolDown; //everytime player attacks timer is set to cooldown
			}
		}
	}

	private void Attack() {
		float distance = Vector3.Distance(target.transform.position, transform.position); // defines the distance the player can hit the enemy

		Vector3 dir = (target.transform.position - transform.position).normalized;

		float direction = Vector3.Dot(dir, transform.forward);

		Debug.Log(distance); // to measure distance in console for defining distances
		if(distance < 10) { // max distance the player can be from enemy to hit
			if(direction > 0) { // makes sure player is facing enemy to hit

				EnemyHealth eh = (EnemyHealth)target.GetComponent("EnemyHealth");
				eh.AdjustCurrentHealth(-10); // enemy loses 10 health for each attack it is hit by
	
		}
		}
	}
}
