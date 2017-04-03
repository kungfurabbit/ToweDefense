using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Build : MonoBehaviour {
	public GameObject rendpart1, rendpart2;
	public Color setColor;
	public List<GameObject> Points = new List<GameObject>();
	public float[] Distance;
	public BuildManager BM;

	void Start () {
		BM = GameObject.FindGameObjectWithTag ("Player").GetComponent<BuildManager> ();
	}
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
		ChekDistance ();
	}
	void ChekDistance(){
		int i = 0;
		foreach (GameObject go in Points) {
			RaycastHit hit;
			if (Physics.Raycast (go.transform.position, Vector3.down, out hit, 20f)) {
				Distance [i] = hit.distance;
			}
			i++;
		}
		ChangeColor ();
	}

	void ChangeColor(){
		if (Distance [0] == Distance [1]) {
			setColor = new Color (255, 255, 0, 0.4f);
			BM.can_build = true;
		} else {
			setColor = new Color (255, 0, 0, 0.4f);
			BM.can_build = false;
		}
		rendpart1.GetComponent<Renderer> ().material.color = setColor;
		rendpart2.GetComponent<Renderer> ().material.color = setColor;
	}
}
