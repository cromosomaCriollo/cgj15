using UnityEngine;
using System.Collections;

public class Friction : MonoBehaviour {
	public float MaxTime = 2.0f;
	private float TimerFriction;
	public float InitialFriction = 3.0f;
	public float rate = 0.5f;
	public GameObject self;

	// Use this for initialization
	void Start () {
		self.collider2D.sharedMaterial.friction = InitialFriction;
		TimerFriction = MaxTime;
		InitialFriction -= rate;
	}
	
	// Update is called once per frame
	void Update () {
		if (InitialFriction != 0)
			TimerFriction -= Time.deltaTime;
		if (TimerFriction <= 0) {
			Debug.Log (TimerFriction);
			if (InitialFriction <= 0.2f) {
				InitialFriction = 0;
				self.collider2D.sharedMaterial.friction = InitialFriction;
			}else{
				self.collider2D.sharedMaterial.friction = InitialFriction;
				TimerFriction = MaxTime;
			}
			InitialFriction -= rate;
		}


	}
}
