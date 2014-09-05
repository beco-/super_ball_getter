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
		GameSystemScript gamesystemscript = (GameSystemScript)(obj.GetComponent("GameSystemScript"));

		if(collider.gameObject.name == ("unitychan")){
			// Delete gotten SuperBall.
			Destroy(gameObject);
			
			if(gameObject.name == ("SuperBallGoal")){
				gamesystemscript.superballCounter += 10;
				gamesystemscript.step = GameSystemScript.STEP.GOAL;
			}
			else{
				gamesystemscript.superballCounter++;
			}
		}
	}
}
