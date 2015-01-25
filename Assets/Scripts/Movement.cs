using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movement : MonoBehaviour {
	public float Speed = 10.0f;
	public float dolares = 0.0f;
	public GameObject Idle;
	public GameObject Side;
	private float Horizontal = 0.0f;
	private float angle;
	public float TiltCD = 1.0f;
	private float CurrentCD;
	public Text Plata;
	public float ScoreFinish = 500.0f;
	public bool paused = false;
	public bool BlowWind = false;
	public GameOver Gameover;

	void Start () {
		CurrentCD = TiltCD;
	}


	// Update is called once per frame
	void FixedUpdate () {

		//Movimiento
		Horizontal = Input.GetAxis ("Horizontal");
		if (Horizontal == 0) {
			Horizontal = Input.acceleration.x;
		}
		Vector2 Vector = new Vector2 (Horizontal, Horizontal/2) * Speed + SoplarViento(BlowWind);
		Vector2 VectorA = new Vector2 (Input.acceleration.x, Horizontal/2) * Speed + SoplarViento (BlowWind); //vector ligeramente angulado hacia abajo
		rigidbody2D.AddForce (Vector);	//movimiento pc
		rigidbody2D.AddForce (VectorA); //movimiento movil 

	}

	void Update ()
	{

		//Tilting

		angle = transform.localEulerAngles.z;
		//Debug.Log (angle);
		if (CurrentCD <= TiltCD && paused == false) {
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
			transform.localScale = new Vector3 (-3.459093f, transform.localScale.y, transform.localScale.z);
		} else if (Horizontal < 0){
			transform.localScale = new Vector3 (3.459093f, transform.localScale.y, transform.localScale.z);
		}

		CalcularDireccion (transform.localEulerAngles, paused);
		DanoPorTiempo ();
		Plata.text = dolares.ToString ("0.00");
		// para pruebas
		if (dolares >= ScoreFinish) {
			paused = true;
			Time.timeScale = 0;
			Gameover.Over();
			}

	}

	public void CalcularDireccion(Vector3 angulo, bool paused) {
		if (!paused) {
			if (angulo.z <= 45) {
				
				calcularDano(angulo.z);
			} else if ((angulo.z >= 315 && angulo.z <= 360)) {
				calcularDano(angulo.z - 315);
			} else {
				calcularDano(100);
			}
				}
				
		}
	public void calcularDano(float angulo){
		float ratio;
		if (angulo < 10) {
			ratio = 0;
		} else if (angulo >= 10 && angulo < 18) {
			ratio = 2.8f;		//entre 10 y 17
		} else if (angulo >= 18 && angulo < 30) {
			ratio = 4.2f;		//entre 18 a 30°
		} else {
			ratio =8.75f;	//cualquier otro angulo
		}
		dolares += ratio * Time.deltaTime;
		//Debug.Log (ratio);
	}

	public void DanoPorTiempo(){
		dolares += 1.75f * Time.deltaTime;
	}


	public Vector2 SoplarViento(bool _BlowWind){
		if (_BlowWind) {
			float Ponquesito = Random.Range (0.5f, 4.0f);
			return new Vector2 (Ponquesito, 0.0f);
		} else {
			return new Vector2(0.0f, 0.0f);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Piso") {
			dolares += 1200.0f * Time.deltaTime;
		}
	}



}
