using UnityEngine;
using System.Collections;


public class GameOver : MonoBehaviour {
	
	public CanvasScript HUD;

	public void Over(){
		HUD.gameObject.SetActive (false);
		transform.Find("GameOver").gameObject.SetActive(true);
		transform.Find ("Black").gameObject.SetActive (true);
		HUD.transform.Find ("VolverMenu").gameObject.SetActive (true);
		HUD.transform.Find ("Restart").gameObject.SetActive (true);
	}
}
