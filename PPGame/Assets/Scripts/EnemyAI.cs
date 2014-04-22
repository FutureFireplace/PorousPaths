using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;
	public int maxDistance;

	private Transform myTransform;

	void Awake() {
		myTransform = transform; // caches the transform data from unity into a variable
	}

	// Use this for initialization
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag("Player"); // will make the gameobject target the player by using tags

		target = go.transform;

		maxDistance = 5;
	}
	
	// Update is called once per frame
	void Update () {

		// creates a line between the object(enemy) to the player to indicate it is targeted
		Debug.DrawLine(target.transform.position, myTransform.position); 

		// will cause the enemy to look at the player
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
	
		if(Vector3.Distance(target.position, myTransform.position) > maxDistance) { // will stop the enemy from spinning around player when it gets too close
		// Will cause the enemy to move towards the player
		myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
	}
	}
}
