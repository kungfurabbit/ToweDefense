using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Xft;

[System.Serializable]
public class Spells {
	public string name;
	public int cost;
	public int Maxdmg, Mindmg;
	public Texture2D img;
	public GameObject spell_prefab;


}

public class Spells_Controller : MonoBehaviour {
	public List<Spells> spell = new List<Spells>();
	[HideInInspector]
	public int count;
	private int dmg;
	private Attack AT;
	private GameObject[] enemy;

	// Use this for initialization
	void Start () {
		AT = gameObject.GetComponent<Attack> ();
	}
	
	// Update is called once per frame
	void Update () {
		Spell1 ();
	}

	void DealDmg(int min,int max){
		dmg = Random.Range (min, max);
	}
	void Enemy_triggerd(){
		enemy = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (GameObject go in enemy) {
			go.GetComponent<TakeDamage> ().count = 1;
		}
	}
	void Spell1(){
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			Enemy_triggerd ();
			AT.SimpleTrail.Activate ();
			DealDmg (spell [0].Mindmg, spell [0].Maxdmg);
			spell [0].spell_prefab.SendMessage ("GetDamage", dmg, SendMessageOptions.DontRequireReceiver);
			spell[0].spell_prefab.GetComponent<BoxCollider> ().enabled = true;
			count = 1;
			AT.anim.SetBool ("Spell1", true);
			Invoke ("Stop_Spell1", 1f);
		}
	}

	#region stop_anim
	void Stop_Spell1(){
		AT.anim.SetBool ("Spell1", false);
		AT.SimpleTrail.Deactivate();
		spell[0].spell_prefab.GetComponent<BoxCollider> ().enabled = false;
		count = 0;
	}
	#endregion
		
}

