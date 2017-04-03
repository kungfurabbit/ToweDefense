using UnityEngine;
using System.Collections;

public class MeleeTriger : MonoBehaviour {
	public int count;
	private int damage;
	// Use this for initialization

	public void GetDamage(int dmg){
		damage = dmg;
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Enemy" && count ==1) {
			count = 0;
			Debug.Log ("Boom");
			other.GetComponent<Enemy_info> ().TakeDamage (damage);

		}

	}
}
