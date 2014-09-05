using UnityEngine;
using System.Collections;

public class TranslatePlateScript : MonoBehaviour {
	bool roundtripFlg = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Roundtrip process of the plane.
		if((transform.position.z > 44.25f) && (roundtripFlg == true)){
			transform.Translate(transform.forward * -0.05f);
			
			if(transform.position.z <= 44.25f){
				roundtripFlg = false;
			}
		}
		else if((transform.position.z < 60.5f) && (roundtripFlg == false)){
			transform.Translate(transform.forward * 0.05f);
			
			if(transform.position.z >= 60.5f){
				roundtripFlg = true;
			}
		}
	}
	// Unitychan moves together with the plate, but the movement isn't smooth!!
	/*
	void OnCollisionStay(Collision collision){
		if((collision.gameObject.name == "unitychan") && (roundtripFlg == true)){
			collision.gameObject.transform.Translate(transform.forward * -0.05f);
		}
		if((collision.gameObject.name == "unitychan") && (roundtripFlg == false)){
			collision.gameObject.transform.Translate(transform.forward * 0.05f);
		}
	}
	*/
}
