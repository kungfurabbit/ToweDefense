using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildManager : MonoBehaviour {
	public GameObject Selected_Tower_Ghost;
	public Transform BuildPoint;
	public List<GameObject> Towers_Ghost = new List<GameObject> ();
	public List<GameObject> Towers_Build = new List<GameObject> ();

	public bool can_build;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && Selected_Tower_Ghost !=null && can_build) {
			Instantiate (Towers_Build [0], Selected_Tower_Ghost.transform.position, Selected_Tower_Ghost.transform.rotation);
			Destroy (Selected_Tower_Ghost);
		}
	}

	void OnGUI ()
	{
		if (GUI.Button (new Rect (Screen.width / 2, Screen.height - 100, 50, 50), "Tower1") || Input.GetKeyDown(KeyCode.Alpha5)) {
			Ghost (0);
		}
	}



	void Ghost(int id){
		if (Selected_Tower_Ghost != null) {
			Destroy (Selected_Tower_Ghost);
		}
		Selected_Tower_Ghost = Instantiate (Towers_Ghost [id], BuildPoint.position, BuildPoint.rotation) as GameObject;
		Selected_Tower_Ghost.transform.parent = gameObject.transform.root;
	}
}
