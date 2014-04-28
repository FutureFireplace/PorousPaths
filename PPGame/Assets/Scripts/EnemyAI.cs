using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;
	public int maxDistance;
	public float range = 10f;
	public float stop = 3.0f;

	public Transform myTransform;

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

		float distance = Vector3.Distance(myTransform.position, target.position);

		// creates a line between the object(enemy) to the player to indicate it is targeted
		// Debug.DrawLine(target.transform.position, myTransform.position); 

		// will cause the enemy to look at the player
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
	
		if(Vector3.Distance(target.position, myTransform.position) > maxDistance) { // will stop the enemy from spinning around player when it gets too close
		
		}
		// Will cause the enemy to move towards the player
		else if (distance <= range) {
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
			Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
			animation.CrossFade ("HetWalk0");
			Debug.Log(distance);
				}
	}
}
