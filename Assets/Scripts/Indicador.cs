using UnityEngine;
using System.Collections;

public class Indicador : MonoBehaviour {
	public Movement target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float angulo = target.transform.eulerAngles.z * 2f;
		transform.eulerAngles = new Vector3 (0.0f, 0.0f, angulo);
	
	}
}
