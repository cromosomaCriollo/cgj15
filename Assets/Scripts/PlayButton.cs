using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	public void NextScene()
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Application.LoadLevel ("MainScene");
	}
}
