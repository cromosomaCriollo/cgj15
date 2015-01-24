using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	public void OnClick ()
	{

		Application.LoadLevel (Application.loadedLevelName);
		if (Time.timeScale == 0) {
			Time.timeScale = 1;
				}
	}


}
