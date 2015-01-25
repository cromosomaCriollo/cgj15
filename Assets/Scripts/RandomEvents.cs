using UnityEngine;
using System.Collections;

public class RandomEvents : MonoBehaviour {

	public float Timer = 8.0f;
	private float CurrentTimer;
	public Movement target;                                                                                          
	private bool entro = true;

	void Start () {
		CurrentTimer = Timer;
	}
	
	// Update is called once per frame
	void Update () {
		CurrentTimer -= Time.deltaTime;
		if (CurrentTimer <= 0) {
			if (Random.Range(0, 1) == 1 && entro){
				entro = false;
				target.BlowWind = true;	
				//instanciar los sprite wind, bla bla
			}else{ 
				if (!entro){
					if (CurrentTimer <= -2.0f){
						target.BlowWind = false;
						CurrentTimer = Timer;
						entro = true;
					}
				}else{
					CurrentTimer = Timer;
				}
			}
		}
	}

}
