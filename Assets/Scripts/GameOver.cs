using UnityEngine;
using System.Collections;


public class GameOver : MonoBehaviour {
	
	public CanvasScript HUD;

	public void Over(){
		HUD.transform.Find ("HUD1").gameObject.SetActive (false);
		HUD.transform.Find ("HUD2").gameObject.SetActive (false);
		HUD.transform.Find ("Indicador").gameObject.SetActive (false);

		HUD.transform.Find ("VolverMenu").gameObject.SetActive (true);
		HUD.transform.Find ("Restart").gameObject.SetActive (true);
		transform.Find ("Black").gameObject.SetActive (true);
		transform.Find("GameOver").gameObject.SetActive(true);

	}

}
