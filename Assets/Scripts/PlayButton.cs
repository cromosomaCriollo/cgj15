using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	public bool animation_bool = false;

	public void NextScene()
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Application.LoadLevel ("MainScene");
	}

	public void PressedDown  ()
	{
		if (animation_bool) {
			animation.Play();
			NextScene();
		}
	}
}
