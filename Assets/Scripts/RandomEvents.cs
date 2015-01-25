using UnityEngine;
using System.Collections;

public class RandomEvents : MonoBehaviour {

	public float Timer = 8.0f;
	private float CurrentTimer;
	public Movement target;                                                                                          
	private bool entro = true;
	public GameObject PrefabWind;
	public Arrows ArrowsPlaceholder;
	private float ArrowsPlaceholderX;
	void Start () {
		CurrentTimer = Timer;
		ArrowsPlaceholderX = ArrowsPlaceholder.transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		CurrentTimer -= Time.deltaTime;
		if (CurrentTimer <= 0) {
			if (Random.Range (0, 2) == 1 && entro){
				//instanciar los sprite wind, bla bla
				entro = false;
				float dir;
				if (Random.Range (0, 2) == 0){
					target.WindDirection = 'D';
					dir = -1.00f;
				}else{
					target.WindDirection = 'I';
					dir = 1.00f;
				}
				ArrowsPlaceholder.gameObject.SetActive(true);
				if (dir <= -1.00f){

					ArrowsPlaceholder.transform.localScale = new Vector3 (-ArrowsPlaceholderX, ArrowsPlaceholder.transform.localScale.y, transform.localScale.z);
				}
				for (int i = 0; i < 10; i++) {
					ArrowsPlaceholder.transform.Find ("WindArrow").gameObject.SetActive (false);
					ArrowsPlaceholder.transform.Find ("WindArrow").gameObject.SetActive (true);
				}
				GameObject WindI = (GameObject) Instantiate(PrefabWind, new Vector3 (14.14f * dir, 7.32f, -4.2f), Quaternion.Euler(0.0f, 270.0f*dir, 90.0f));
				target.BlowWind = true;	
				Destroy(WindI, 2.0f);
				if (dir <= -1.00f){
					ArrowsPlaceholder.transform.localScale = new Vector3 (-ArrowsPlaceholderX, ArrowsPlaceholder.transform.localScale.y, transform.localScale.z);
				}
				ArrowsPlaceholder.gameObject.SetActive(false);
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
