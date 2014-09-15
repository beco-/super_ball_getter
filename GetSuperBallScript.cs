using UnityEngine;
using System.Collections;

public class GetSuperBallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider){
		GameObject obj = GameObject.Find("GameSystemBox");
		GameSystemScript gameSystemScript = (GameSystemScript)(obj.GetComponent("GameSystemScript"));

		if(collider.gameObject.name == ("unitychan")){
			// Delete gotten SuperBall.
			Destroy(gameObject);
			
			if(gameObject.name == ("SuperBallGoal")){
				gameSystemScript.superballCounter += 10;
				gameSystemScript.step = GameSystemScript.STEP.GOAL;
			}
			else{
				gameSystemScript.superballCounter++;
			}
		}
	}
}
