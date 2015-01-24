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
		//sameText.text = TimerF.ToString();
//		someText.text = ((int) TimerF).ToString ();
		// para pruebas
		someText.text = TimerF.ToString ("0.00");

	}
}
