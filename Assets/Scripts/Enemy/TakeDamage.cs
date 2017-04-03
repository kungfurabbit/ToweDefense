using UnityEngine;
using System.Collections;

public class TakeDamage : MonoBehaviour {
	public int count;

	void OnTriggerStay(Collider other){
		if (other.tag == "AOEskill" &&count==1) {
			count = 0;
			Debug.Log ("Boom");
			gameObject.GetComponent<Enemy_info> ().TakeDamage (other.GetComponent<AOEskill> ().damage);


		}

	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
}
