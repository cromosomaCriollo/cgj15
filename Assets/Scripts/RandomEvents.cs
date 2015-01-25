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
		Debug.Log (CurrentTimer);
		if (CurrentTimer <= 0) {
			if (Random.Range (0, 2) == 1 && entro){
				entro = false;
				target.BlowWind = true;	
				float dir;
				if (Random.Range (0, 2) == 1){
					target.WindDirection = 'D';
					dir = 1.00f;
				}else{
					target.WindDirection = 'I';
					dir = -1.00f;
				}
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
