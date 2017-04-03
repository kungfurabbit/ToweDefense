using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour {
	public float maxHealth,maxMana,curHealth,curMana;
	public GameObject healthObj;
	public Text healthText;
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Death ();
		healthObj.transform.localScale = new Vector3 (curHealth / maxHealth, 1, 1);
		healthText.text =  curHealth.ToString ("0")+ "/" + maxHealth.ToString ("0");
	}

	public void TakeDamage(int dmg){
		curHealth -= dmg;
		anim.SetBool ("TakeHitBlock", true);
		Invoke ("StopAnim", 0.5f);
	}

	void Death(){
	
		if (curHealth <= 0) {
			anim.SetBool ("Death", true);
		} 
	}
	void StopAnim(){
	
		anim.SetBool ("TakeHitBlock", false);
	}


	}

