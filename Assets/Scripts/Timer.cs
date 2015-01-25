using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	public Text someText;
	public float TimerF = 0.0f;

	//public Text sameText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		TimerF = TimerF + Time.deltaTime;
		someText.text = MascaraMinutos(TimerF);
		// para pruebas
		//someText.text = TimerF.ToString ("0.00");

	}
	public string MascaraMinutos(float tiempo) {
		string mensaje = "";
		int minutos = (int)tiempo / 60;
		int segundos = (int)tiempo - (60 * minutos);
		if (minutos < 1) {
				mensaje = segundos + " s";
		} else {
				if (segundos > 0) {
					mensaje = minutos + " m, " + segundos + " s";						
				} else {
					mensaje = minutos + " m";	
				}

		}
		return  mensaje;				
	}
}
