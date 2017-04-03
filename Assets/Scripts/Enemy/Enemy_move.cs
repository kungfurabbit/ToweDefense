using UnityEngine;
using System.Collections;

public class Enemy_move : MonoBehaviour {
	[HideInInspector] public int waypointIndex;
	[HideInInspector] public Transform target;
	public float speed;
	public float turnSpeed = 10f;
	private Animator anim;
	private float time;

	// Use this for initialization
	void Start () {
		target = WayPoints.points [0];
		anim = gameObject.GetComponent<Animator> ();
	}

	void Update(){
		Move ();
	}
	// Update is called once per frame
	void Move () {
		Vector3 dir = target.position - transform.position;

		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
		if(target.tag != "Player")
			transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
		if (target.tag == "Player") {
			if (Vector3.Distance (transform.position, target.transform.position) < 2f) {
				anim.SetBool ("Attack", true);
				if (Time.time > time) {
					target.SendMessage ("TakeDamage", 5, SendMessageOptions.DontRequireReceiver);
					time = Time.time + 1.2f;
				}
			} else {
				transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
				anim.SetBool ("Attack",false);
			}
			return;
		}
		if (Vector3.Distance(transform.position, target.position) <= 0.2f)
		{	
			GetNextWaypoint();
		}
	}

	void GetNextWaypoint ()
	{
		if (waypointIndex >= WayPoints.points.Length - 1) {
			//Attack();
			return;
		}
		waypointIndex++;
		target = WayPoints.points [waypointIndex];

	}

	/*void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			target = GameObject.FindGameObjectWithTag ("Player").transform;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.tag == "Player") {
			target = WayPoints.points [waypointIndex];
		}

	}*/

}
