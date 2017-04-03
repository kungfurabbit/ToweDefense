using UnityEngine;
using System.Collections;

public class Enemy_see : MonoBehaviour {
	private Enemy_move e_m;
	public GameObject enemy;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			e_m.target = GameObject.FindGameObjectWithTag ("Player").transform;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.tag == "Player") {
			e_m.target = WayPoints.points [e_m.waypointIndex];
		}

	}
	// Use this for initialization
	void Start () {
		e_m = enemy.GetComponent<Enemy_move> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
