using UnityEngine;
using System.Collections;
using Xft;

public class Attack : MonoBehaviour {
	public XWeaponTrail SimpleTrail;
	public GameObject weapon;
	private bool block=false;
	[HideInInspector]	
	public Animator anim;

	void Start(){
		SimpleTrail.Init();
		SimpleTrail.Deactivate();
		anim = gameObject.GetComponent<Animator> ();
	}


	void Update(){
		Attacking ();
		Block ();

	/*	if(Input.GetKey(KeyCode.Alpha1)){
			SimpleTrail.Activate();
			spells[1].GetComponent<BoxCollider> ().enabled = true;
			spells[1].GetComponent<MeleeTriger> ().count = 1;
			anim.SetBool ("Spell1", true);
			Invoke ("Stop_Attack", 1f);
		}*/

	}

	void Attacking(){
		if(Input.GetMouseButtonDown(0)){
			SimpleTrail.Activate();
			weapon.SendMessage ("GetDamage", 20, SendMessageOptions.DontRequireReceiver);
			weapon.GetComponent<BoxCollider> ().enabled = true;
			weapon.GetComponent<MeleeTriger> ().count = 1;
			anim.SetBool("Attack",true);
			Invoke ("Stop_Attack", 1f);
		}
	}

	void Block(){
		if (Input.GetMouseButtonDown (1) && !block) {
			anim.SetBool ("Block", true);
			block = true;
		} 
		if(Input.GetMouseButtonUp (1) && block){
			anim.SetBool ("Block", false);
			block = false;
		}
	}

	void Stop_Attack(){
		anim.SetBool("Attack",false);
		weapon.GetComponent<BoxCollider> ().enabled = false;
		SimpleTrail.Deactivate();
	}


}
