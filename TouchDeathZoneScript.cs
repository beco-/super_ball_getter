using UnityEngine;
using System.Collections;

public class TouchDeathZoneScript : MonoBehaviour {
	GameObject obj;
	GameSystemScript gameSystemScript;




	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider){
		obj = GameObject.Find("GameSystemBox");
		gameSystemScript = (GameSystemScript)(obj.GetComponent("GameSystemScript"));

		if(collider.gameObject.name  == ("unitychan")){
			if((gameSystemScript.step != GameSystemScript.STEP.TIME_OVER)
				&& (gameSystemScript.step != GameSystemScript.STEP.GOAL)){ // Avoid overlap.
				gameSystemScript.step = GameSystemScript.STEP.GAME_OVER;
			}
		}
	}
}
