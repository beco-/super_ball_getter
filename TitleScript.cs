using UnityEngine;
using System.Collections;

public class TitleScript : MonoBehaviour {
	private AudioSource seGet;
	private AudioSource seSuperballgetter01;

	private bool pushFlg = false;
	private float systemTimer = 10000.0f;
	private float textTimer = 0.0f;

	// Use this for initialization
	void Start () {
		AudioSource[] audioSources = GetComponents<AudioSource>();
		seGet = audioSources[0];
		seSuperballgetter01 = audioSources[1];
	}
	
	// Update is called once per frame
	void Update () {
		DisplayPushEnterKey();

		if(Input.GetKeyDown(KeyCode.Return) && pushFlg == false){
			seGet.PlayOneShot(seGet.clip);
			systemTimer = -3.8f; // Wait for 3.8 seconds before going to game stage.
			pushFlg = true;
		}
		if((systemTimer > 0.0f) && (pushFlg == true)){
			Application.LoadLevel("Stage1");
		}
		systemTimer += Time.deltaTime;
	}

	void DisplayPushEnterKey(){
		GameObject pushEnterKeyText = GameObject.Find("PushEnterKeyText");
		textTimer += Time.deltaTime;

		// Blink the text.
		if(textTimer < 1.0f){
			pushEnterKeyText.guiText.text = "Push Enter Key";
		}
		else if(textTimer >= 1.0){
			pushEnterKeyText.guiText.text = null;
			
			if(textTimer >= 1.5f){
				textTimer = 0.0f; // Reset timer.
			}
		}
	}
}
