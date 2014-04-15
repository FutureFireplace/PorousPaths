using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class spydAnim : MonoBehaviour {
	
	public float movementSpeed = 10;
	public float turningSpeed = 60;	
	public long clockInit = 0;


	// Use this for initialization
	void Start () {
		StreamWriter sw1 = new StreamWriter("tilCSV.txt", true);
		string stringNow = System.DateTime.Now.Ticks.ToString();
		clockInit = System.DateTime.Now.Ticks;
		sw1.WriteLine("Left, Right");
		sw1.Close();
	}
	
	// Update is called once per frame
	void Update () {
		
		float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
		transform.Rotate(0, horizontal, 0);
		
		//float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
		//transform.Translate(0, 0, vertical);
		if(Input.GetKey("space"))
		{
			animation.CrossFade("Spyd1");

			// Get the directories currently on the C drive.
			//DirectoryInfo[] cDirs = new DirectoryInfo(@"c:\").GetDirectories();
			
			// Write each directory name to a file - outcomment gemt for at se hvordan det virker:
			/*using (StreamWriter sw = new StreamWriter("CDriveDirs.txt"))
			{
				foreach (DirectoryInfo dir in cDirs)
				{
					sw.WriteLine(dir.Name);					
				}
			}*/
		}	

		/*
		Item,Cost,Sold,Profit
		Keyboard,$10.00,$16.00,$6.00
		Monitor,$80.00,$120.00,$40.00
		Mouse,$5.00,$7.00,$2.00
		,,Total,$48.00
		 */

		if((Input.GetKeyDown(KeyCode.LeftArrow)))
		{
			StreamWriter sw1 = new StreamWriter("tilCSV.txt", true);
			long rightNow = System.DateTime.Now.Ticks;
			long diffRight = rightNow - clockInit;
			string stringNow = diffRight.ToString();
			sw1.WriteLine(stringNow + ",0");
			sw1.Close();

		}
		if((Input.GetKeyDown(KeyCode.RightArrow)))
		{
			StreamWriter sw1 = new StreamWriter("tilCSV.txt", true);
			long leftNow = System.DateTime.Now.Ticks;
			long diffLeft = leftNow - clockInit;
			string stringNow = diffLeft.ToString();
			sw1.WriteLine("0,"+stringNow);
			sw1.Close();
			
		}
	}
}

