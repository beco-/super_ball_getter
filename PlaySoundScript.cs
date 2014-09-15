using UnityEngine;
using System.Collections;

public class PlaySoundScript: MonoBehaviour {
	private AudioSource seGet;
	private AudioSource sePyon;
	private AudioSource seAareee;
	private AudioSource seIchi;
	private AudioSource seNii;
	private AudioSource seSan;
	private AudioSource seShii;
	private AudioSource seGoal;
	private AudioSource seReady;
	private AudioSource seGo;
	private AudioSource bgmStage1;
	private AudioSource bgmGoal;
	private AudioSource seTimeover;
	private AudioSource bgmPerfect;

	GameObject obj;
	GameSystemScript gameSystemScript;
	int playCounter;
	
	// Use this for initialization
	void Start () {
		AudioSource[] audioSources = GetComponents<AudioSource>();
		seGet = audioSources[0];
		sePyon = audioSources[1];
		seAareee = audioSources[2];
		seIchi = audioSources[3];
		seNii = audioSources[4];
		seSan = audioSources[5];
		seShii = audioSources[6];
		seGoal = audioSources[7];
		seReady = audioSources[8];
		seGo = audioSources[9];
		bgmStage1 = audioSources[10];
		bgmGoal = audioSources[11];
		seTimeover = audioSources[12];
		bgmPerfect = audioSources[13];

		obj = GameObject.Find ("GameSystemBox");
		gameSystemScript = (GameSystemScript)(obj.GetComponent("GameSystemScript"));
		playCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		PlayReadyGo();
		PlayTimeOver();
	}


	void PlayReadyGo(){
		if((gameSystemScript.step == GameSystemScript.STEP.START) && (playCounter == 0)){
			seReady.PlayOneShot(seReady.clip);
			playCounter++; // Avoid reloading.
		}
		else if((gameSystemScript.step == GameSystemScript.STEP.MOVE) && (playCounter == 1)){
			seGo.PlayOneShot(seGo.clip);
			bgmStage1.Play();
			playCounter++; // Avoid reloading.
		}
	}

	void PlayTimeOver(){
		if(gameSystemScript.step == GameSystemScript.STEP.TIME_OVER && (playCounter == 2)){
			seTimeover.PlayOneShot(seTimeover.clip);
			playCounter++; // Avoid reloading.
		}
	}


	void PlayJumpSound(AudioClip sePyon){
		audio.PlayOneShot(sePyon); // with setting animation event(unitychan_JUMP00)
	}


	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.name.StartsWith("SuperBall")){
			seGet.PlayOneShot(seGet.clip);
		}
		else if(collider.gameObject.name == "DeathZone"){
			seAareee.PlayOneShot(seAareee.clip);
		}

		if(collider.gameObject.name == "SuperBallGoal"){
			bgmStage1.Stop();

			if(gameSystemScript.superballCounter >= 50){
				bgmPerfect.Play();
			}
			else{
				bgmGoal.Play();
			}
		}
	}

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.name == "LastSteps0"){
			seIchi.PlayOneShot(seIchi.clip);
		}
		else if(collision.gameObject.name == "LastSteps1"){
			seNii.PlayOneShot(seNii.clip);
		}
		else if(collision.gameObject.name == "LastSteps2"){
			seSan.PlayOneShot(seSan.clip);
		}
		else if(collision.gameObject.name == "LastSteps3"){
			seShii.PlayOneShot(seShii.clip);
		}
		else if(collision.gameObject.name == "Goal"){
			seGoal.PlayOneShot(seGoal.clip);
		}
	}
}
