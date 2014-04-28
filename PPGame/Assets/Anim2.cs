using UnityEngine;
using System.Collections;

public class Anim2 : MonoBehaviour {

	public float movementSpeed = 10;
	public float turningSpeed = 60;
	public GameObject body;
	public GameObject clothes;
	public GameObject rope;
	public GameObject shoes;
	public GameObject weapon;


	// Use this for initialization
	void Start () {
	
	}

	void animate() {
		if(Input.GetAxis("Vertical") > 0) {
			body.animation.CrossFade("HetWalk0");
			clothes.animation.CrossFade("HetWalkKlaeder");
			shoes.animation.CrossFade("HetWalkSko");
			rope.animation.CrossFade("HetWalkReb");
			weapon.animation.CrossFade("SpydRyg");
		}
	}
	
	// Update is called once per frame
	void Update () {

		float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
		transform.Rotate(0, horizontal, 0);
		
		float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
		transform.Translate(0, 0, vertical);

		animate ();
	
	}
}
