using UnityEngine;
using System.Collections;

public class CarrieryWP : MonoBehaviour {
	
	public Transform Target1;
	public Transform Target2;
	public Transform Target3;
	public Transform Target4;
	public Transform Target5;
	public Transform Target6;
	public Transform Target7;
	public Transform Target8;
	public Transform Target9;
	
	public float speed = 5;
	public float rotationSpeed = 4.0f;
	public float distToWaypoint = 5.0f;

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {  


		
		if(transform.position.x < Target1.position.x )
		{
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, Target1.position, step);

		}
		
		if(transform.position.x < Target2.position.x && transform.position.x > Target1.position.x-distToWaypoint)
		{
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, Target2.position, step);
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Target2.position - transform.position), rotationSpeed * Time.deltaTime);
			
		}              
		if(transform.position.x < Target3.position.x && transform.position.x > Target2.position.x-distToWaypoint)
		{
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, Target3.position, step);
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Target3.position - transform.position), rotationSpeed * Time.deltaTime);
			
		}      
		if(transform.position.x < Target4.position.x && transform.position.x > Target3.position.x-distToWaypoint)
		{
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, Target4.position, step);
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Target4.position - transform.position), rotationSpeed * Time.deltaTime);
			
		} 
		if(transform.position.x < Target5.position.x && transform.position.x > Target4.position.x-distToWaypoint)
		{
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, Target5.position, step);
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Target5.position - transform.position), rotationSpeed * Time.deltaTime);
			
		}
		if(transform.position.x < Target6.position.x && transform.position.x > Target5.position.x-distToWaypoint)
		{
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, Target6.position, step);
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Target6.position - transform.position), rotationSpeed * Time.deltaTime);
			
		}
		if(transform.position.x < Target7.position.x && transform.position.x > Target6.position.x-distToWaypoint)
		{
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, Target7.position, step);
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Target7.position - transform.position), rotationSpeed * Time.deltaTime);
			
		}
		if(transform.position.x < Target8.position.x && transform.position.x > Target7.position.x-distToWaypoint)
		{
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, Target8.position, step);
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Target8.position - transform.position), rotationSpeed * Time.deltaTime);
			
		}
		if(transform.position.x < Target9.position.x && transform.position.x > Target8.position.x-distToWaypoint)
		{
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, Target9.position, step);
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Target9.position - transform.position), rotationSpeed * Time.deltaTime);
			
		}
		if(transform.position.x == Target9.position.x && transform.position.z == Target9.position.z)
		{
			Application.LoadLevel("WinScreen");	
		}    
		
	}
}