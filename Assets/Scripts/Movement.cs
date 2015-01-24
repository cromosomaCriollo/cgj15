using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movement : MonoBehaviour {
	public float Speed = 10.0f;
	public float dolares = 150.0f;
	public GameObject Idle;
	public GameObject Side;
	private float Horizontal = 0.0f;
	private float angle;
	public float TiltCD = 1.0f;
	private float CurrentCD;
	public Text Plata;
	public bool paused = false;


	void Start () {
		Speed = PlayerPrefs.GetFloat ("Speed", 3.0f);
		CurrentCD = TiltCD;
	}


	// Update is called once per frame
	void FixedUpdate () {

		//Movimiento
		Horizontal = Input.GetAxis ("Horizontal");
		if (Horizontal == 0) {
			Horizontal = Input.acceleration.x;
		}
		Vector2 Vector = new Vector2 (Horizontal, Horizontal/2) * Speed;
		Vector2 VectorA = new Vector2 (Input.acceleration.x, Horizontal/2) * Speed; //vector ligeramente angulado hacia abajo
		rigidbody2D.AddForce (Vector);	//movimiento pc
		rigidbody2D.AddForce (VectorA); //movimiento movil 

	}

	void Update ()
	{

		//Tilting

		angle = transform.localEulerAngles.z;
		if (CurrentCD <= TiltCD) {
			float tilting = Mathf.Sin(CurrentCD*6);
					
			if (angle + tilting > 360.0f) {
				transform.eulerAngles = new Vector3 (0.0f, 0.0f, angle + tilting - 360.0f);
			} else if (angle + tilting < 0.0f) {
				transform.eulerAngles = new Vector3 (0.0f, 0.0f, angle + tilting + 360.0f);
			} else {
				transform.eulerAngles = new Vector3 (0.0f, 0.0f, angle + tilting);
			}
			CurrentCD = CurrentCD - Time.deltaTime;
		} else {
			CurrentCD = TiltCD;
		}



		//FLIP DE SPRITE
		if (angle >= 0 && angle <= 10 || angle >= 350 && angle <= 360) {
			Idle.SetActive (true);
			Side.SetActive (false);
		} else {
			Idle.SetActive(false);
			Side.SetActive(true);
		}
		if (Horizontal > 0) { 
			transform.localScale = new Vector3 (-2.0f, transform.localScale.y, transform.localScale.z);
		} else if (Horizontal < 0){
			transform.localScale = new Vector3 (2.0f, transform.localScale.y, transform.localScale.z);
		}
		calcularDireccion (transform.localEulerAngles, paused);
		danoPorTiempo ();
		Plata.text = dolares.ToString ("0.00");
		// para pruebas
		if (dolares >= 500f) {
			paused = true;
			Plata.text = "Mortadela";
			Plata.color = Color.red;
			Time.timeScale = 0;

				}

	}

	public void calcularDireccion(Vector3 angulo, bool paused) {
		if (!paused) {
			if (angulo.z <= 45) {
				
				calcularDano(angulo.z);
			} else if ((angulo.z >= 315 && angulo.z < 360)) {
				calcularDano(angulo.z - 315);
			} else {
				calcularDano(100);
			}
				}
				
		}
	public void calcularDano(float angulo){
		float ratio;
		if (angulo < 15) {
			ratio = 2.8f;
				} else if (angulo >= 15 && angulo < 30) {
			ratio = 4.2f;
				} else {
			ratio =8.75f;
				}
			dolares += ratio * Time.deltaTime;
	}

	public void danoPorTiempo(){
		dolares += 1.75f * Time.deltaTime;
	}



}
