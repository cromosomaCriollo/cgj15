using UnityEngine;
using System.Collections;

public class RandomEvents : MonoBehaviour {

	public float Timer = 8.0f;
	private float CurrentTimer;
	public Movement target;                                                                                          
	private bool entro = true;
	public GameObject PrefabWind;
	void Start () {
		CurrentTimer = Timer;
	}
	
	// Update is called once per frame
	void Update () {
		CurrentTimer -= Time.deltaTime;
		if (CurrentTimer <= 0) {
			if (Random.Range (0, 2) == 1 && entro){
				entro = false;
				target.BlowWind = true;	
				float dir;
				if (Random.Range (0, 2) == 0){
					target.WindDirection = 'D';
					dir = -1.00f;
				}else{
					target.WindDirection = 'I';
					dir = 1.00f;
				}
				GameObject WindI = (GameObject) Instantiate(PrefabWind, new Vector3 (14.14f * dir, 7.32f, -4.2f), Quaternion.Euler(0.0f, 270.0f*dir, 90.0f));
				Destroy(WindI, 2.0f);
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
