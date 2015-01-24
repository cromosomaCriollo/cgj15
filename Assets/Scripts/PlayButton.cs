using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	public void NextScene()
	{
		Application.LoadLevel ("MainScene");
	}
}
