using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OnClickUpDown : MonoBehaviour {
	

	public Movement player;
	public Text someText;
	void Start()
	{
		player = (Movement) FindObjectOfType(typeof(Movement));
		someText.text = PlayerPrefs.GetFloat ("Speed", player.Speed).ToString();
	}

	public void Ponquesito (bool button)	
	{
		if (button) {
			player.Speed++;
			PlayerPrefs.SetFloat ("Speed", player.Speed);
		} else {
			player.Speed--;
			PlayerPrefs.SetFloat ("Speed", player.Speed);
		}
		Debug.Log (player.Speed);

		if (someText == null) {
			Debug.Log ("Fallo esa verga");
		} else {
			someText.text = player.Speed.ToString();
		}
	}
}
