using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	public void NextScene()
	{
		//Screen sleepTimeOut = SleepTimeout.NeverSleep;
		Application.LoadLevel ("MainScene");
	}
}
