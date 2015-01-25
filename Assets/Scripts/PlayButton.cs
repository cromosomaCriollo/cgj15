using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {


	public void NextScene()
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		StartCoroutine ("AnimationPlay");
	}

	IEnumerator AnimationPlay (){
		yield return new WaitForSeconds (0.45f);
		Application.LoadLevel ("MainScene");
	}


}
