using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	public void OnClick ()
	{
		if (Time.timeScale == 0) {
			Time.timeScale = 1;
		}
		Application.LoadLevel (Application.loadedLevelName);
	}


}
