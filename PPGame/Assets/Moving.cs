﻿using UnityEngine;
using System.Collections;

using Pathfinding;

public class Moving : MonoBehaviour {
	public Vector3 targetPosition;

	
	//The calculated path
	public Path path;
	
	//The AI's speed per second
	public float speed = 100;
	
	//The max distance from the AI to a waypoint for it to continue to the next waypoint
	public float nextWaypointDistance = 3;
	
	//The waypoint we are currently moving towards
	private int currentWaypoint = 0;
	private Seeker seeker;
	private ThirdPersonCharacter controller;
	
	public void Start () {
		//Get a reference to the Seeker component we added earlier
		seeker = GetComponent<Seeker>();
		controller = GetComponent<ThirdPersonCharacter> ();
		
		
		//Start a new path to the targetPosition, return the result to the OnPathComplete function
		seeker.StartPath (transform.position, targetPosition, OnPathComplete);
	}
	
	public void OnPathComplete (Path p) {
		Debug.Log ("Yey, we got a path back. Did it have an error? "+p.error);
		if (!p.error) {
			path = p;
			//Reset the waypoint counter
			currentWaypoint = 1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 100)) {
				targetPosition = new Vector3(hit.point.x,
				                             hit.point.y,
				                             hit.point.z);
				
				seeker.StartPath (transform.position, targetPosition, OnPathComplete);
			}
		}
	}
	
	public void FixedUpdate () {
		if (path == null) {
			controller.Move (Vector3.zero, false, false, Vector3.zero);
			return;
		}
		
		if (currentWaypoint >= path.vectorPath.Count) {
			Debug.Log ("End Of Path Reached");
			path = null;
			return;
		}
		
		//Direction to the next waypoint
		Vector3 dir = (path.vectorPath[currentWaypoint]-transform.position).normalized;
		dir *= speed * Time.fixedDeltaTime;
		controller.Move (dir, false, false, dir);

		
		//Check if we are close enough to the next waypoint
		//If we are, proceed to follow the next waypoint
		if (Vector3.Distance (transform.position,path.vectorPath[currentWaypoint]) < nextWaypointDistance) {
			currentWaypoint++;
			return;
		}
	}
}