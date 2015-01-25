using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	//public Animator mainMenuAnimator;

	public void NextScene()
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		StartCoroutine ("AnimationPlay");
	}

	IEnumerator AnimationPlay (){
		//AnimationInfo[] CurrentClip = mainMenuAnimator.GetNextAnimationClipState (0);

		//yield return new WaitForSeconds (CurrentClip [0].clip.length);
		yield return new WaitForSeconds (0.45f);
		Application.LoadLevel ("MainScene");
	}


}
