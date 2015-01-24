using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float Speed = 3.0f;
	// Use this for initialization
	public GameObject Idle;
	public GameObject Side;
	private float Horizontal = 0.0f;
	void Start () {
		Speed = PlayerPrefs.GetFloat ("Speed", 3.0f);
	}

	public void File ()
	{
		PlayerPrefs.SetFloat ("Speed", Speed);
	}

	// Update is called once per frame
	void FixedUpdate () {

		//Movimiento
		Horizontal = Input.GetAxis ("Horizontal");
		if (Horizontal == 0) {
			Horizontal = Input.acceleration.x;
		}
		Vector2 Vector = new Vector2 (Horizontal, Horizontal/2) * Speed;
		Vector2 VectorA = new Vector2 (Input.acceleration.x, Horizontal/2) * Speed;
		rigidbody2D.AddForce (Vector);
		rigidbody2D.AddForce (VectorA);
		//if (horizontal != 0) {
			//Debug.LogWarning (Vector);
		//}
	}

	void Update ()
	{
		//Debug.Log (Self.);
		//Debug.Log (HingeJoint2D.angle);

		//Tilting
		transform.Rotate(new Vector3 (0.0f, 0.0f, 20.0f));

		//FLIP DE SPRITE
		if (Horizontal > 0) { 
			transform.localScale = new Vector3 (-2.0f, transform.localScale.y, transform.localScale.z);
			Idle.SetActive(false);
			Side.SetActive(true);
		} else if (Horizontal < 0){
			transform.localScale = new Vector3 (2.0f, transform.localScale.y, transform.localScale.z);
			Idle.SetActive(false);
			Side.SetActive(true);
		}else{
			Idle.SetActive(true);
			Side.SetActive(false);
		}
	}
}
