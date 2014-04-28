using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Targeting : MonoBehaviour {
	
	public List<Transform> targets;
	public Transform selectedTarget;
	
	private Transform myTransform;
	
	
	// Use this for initialization
	void Start () {
		targets = new List<Transform>();
		selectedTarget = null;
		myTransform = transform;

		
	}
	
	public void AddAllTargets()
	{
		GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");

		targets.Clear ();
		foreach(GameObject enemy in go)
			AddTarget (enemy.transform);
		
	}
	
	public void AddTarget(Transform enemy)
	{
		targets.Add(enemy);
	}
	
	private void SortTargetsByDistance()
	{
		targets.Sort(delegate(Transform t1, Transform t2) {
			return Vector3.Distance(t1.position, myTransform.position).CompareTo(Vector3.Distance(t2.position, myTransform.position)); 
		});// will sort targets relative to your own position. Closest will be targeted first
	}
	
	private void TargetEnemy()
	{
		AddAllTargets();

		if(selectedTarget == null) {
			SortTargetsByDistance();
			selectedTarget = targets[0];
		}
		else
		{
			int index = targets.IndexOf(selectedTarget);
			
			if(index < targets.Count - 1)
			{
				index++;
			}
			else
			{
				index = 0;
			}
			DeselectTarget();
			selectedTarget = targets[index];
			
		}
		SelectTarget();
		
	}
	
	private void SelectTarget() //for showing which target is selected
	{
		selectedTarget.Find("Targetsphere").renderer.enabled = true;
		selectedTarget.Find("Targetsphere").renderer.material.color = Color.red;
		
		PlayerAttack pa = (PlayerAttack)GetComponent("PlayerAttack");
		
		pa.setTarget(selectedTarget.gameObject);
	}
	
	private void DeselectTarget ()
	{
		selectedTarget.Find("Targetsphere").renderer.enabled = false;
		selectedTarget = null;
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Tab))
		{
			TargetEnemy();
		}
	}
}