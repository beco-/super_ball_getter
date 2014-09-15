using UnityEngine;
using System.Collections;

public class DeletePanelScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.name  == ("unitychan")){
			Destroy(gameObject, 1.4f);
		}
	}
}
