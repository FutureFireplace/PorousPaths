using UnityEngine;
using System.Collections;

public class EnemyAIUPDATE : MonoBehaviour {

public Transform target; //the enemy's target
	public int rotationSpeed = 3; //speed of turning
	public float range = 50f;
	public float range2 = 50f;
	public float stop = 5.0f;
	public float moveSpeed = 3f; //move speed
	public Transform myTransform; //current transform data of this enemy
	
	void Awake(){

		myTransform = transform; //cache transform data for easy access/preformance
	}

	void Start(){

		target = GameObject.FindWithTag("Player").transform; //target the player

		
		
	}

	void animate() {
			Animation[] anims = GetComponentsInChildren<Animation>();

			foreach (Animation anim in anims) {
				anim.CrossFade("HetWalk0");
			}
	}

	void Update (){
		//rotate to look at the player
		float distance = Vector3.Distance(myTransform.position, target.position);

		if (distance<=range2 && distance>stop){
			
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
			Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
			animate();
			Debug.Log ("hey50");

		}	
	}
}