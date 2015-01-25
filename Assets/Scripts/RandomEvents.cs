using UnityEngine;
using System.Collections;

public class RandomEvents : MonoBehaviour {

	public float Timer = 8.0f;
	private float CurrentTimer;
	public Movement target;                                                                                          
	private bool entro = true;
	public Transform PrefabWind;
	private Object WindI;
	void Start () {
		CurrentTimer = Timer;
	}
	
	// Update is called once per frame
	void Update () {
		CurrentTimer -= Time.deltaTime;
		int Random50 = Random.Range (0, 1);
		Debug.Log (CurrentTimer + " " + Random50);
		if (CurrentTimer <= 0) {
			if (Random50 == 1 && entro){
				entro = false;
				target.BlowWind = true;	
				WindI =  Instantiate(PrefabWind, new Vector3 (16.14f, 7.32f, -4.2f), Quaternion.Euler(0.0f, 270.0f, 90.0f));
				//instanciar los sprite wind, bla bla
			}else{ 
				if (!entro){
					if (CurrentTimer <= -2.0f){
						target.BlowWind = false;
						CurrentTimer = Timer;
						entro = true;
						Destroy(WindI);
					}
				}else{
					CurrentTimer = Timer;
				}
			}
		}
	}

}
