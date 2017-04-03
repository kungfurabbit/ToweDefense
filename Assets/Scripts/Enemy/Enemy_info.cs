using UnityEngine;
using System.Collections;

public class Enemy_info : MonoBehaviour {
	public int health;
	// Use this for initialization
	void Start () {
	
	}

	public void TakeDamage(int dmg){
		health -= dmg;
	}
	// Update is called once per frame
	void Update () {
		Death ();
	}

	void Death(){
		if (health <= 0) {
			Destroy (gameObject);
		}

	}
}
