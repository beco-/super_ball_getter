using UnityEngine;
using System.Collections;

public class RotatePanelScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var v = new Vector3(0f, 0f, 0.4f);
		transform.Rotate(v); 
	}
}
