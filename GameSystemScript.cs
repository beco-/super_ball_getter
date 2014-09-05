using UnityEngine;
using System.Collections;

public class GameSystemScript: MonoBehaviour {
	GameObject unitychan;
	UnityChanControlScriptWithRgidBody moveUnitychan;
	Animator anim;
	
	GameObject startText;

	public enum STEP
	{
		NONE = -1,
		START,
		MOVE,
		GOAL,
		GAME_OVER,
		TIME_OVER
	}
	public STEP step = STEP.NONE;
	private float stepTimer = 0.0f;

	public int superballCounter = 0;

	private float startTime =  99.0f;
	private float timeCounter;
	public bool timePaused = false;

	private int totalScore;
	private float textTimer = 0.0f;

	// Use this for initialization
	void Start () {
		unitychan = GameObject.FindGameObjectWithTag("Player");
		anim = (Animator)(unitychan.GetComponent("Animator"));
		moveUnitychan = (UnityChanControlScriptWithRgidBody)(unitychan.GetComponent("UnityChanControlScriptWithRgidBody"));
		startText = GameObject.Find("StartText");

		step = STEP.START;


		ResetTime();
	
	}
	
	// Update is called once per frame
	void Update () {
		stepTimer += Time.deltaTime;


		switch(step){
			case STEP.START:
			{
				moveUnitychan.enabled = false;

				startText.guiText.text = "Ready";

				if(stepTimer > 3.0f){
					step = STEP.MOVE;
				}
			}
			break;

			case STEP.MOVE:
			{
				moveUnitychan.enabled = true;

				// Wait for one second before beginning to count time.
				if(stepTimer > 4.0f){
					CountTime();
				}
				
				if(stepTimer < 5.0f){
					startText.guiText.text = "Go!";
				}
				else{
					startText.guiText.text = null;
				}
				
				if(timeCounter < 1.0f){
					step = STEP.TIME_OVER;
				}
			}
			break;

			case STEP.GOAL:
			{
				moveUnitychan.enabled = false;
				anim.SetBool("Win", true);
				
				if(superballCounter >= 50){
					GameObject perfectText = GameObject.Find("PerfectText");
					perfectText.guiText.text = "Perfect!!";
					
				}
				else{
					GameObject clearText = GameObject.Find("ClearText");
					clearText.guiText.text = "Game Clear!";
				}
				DisplayTotalScore();
				
				DisplayPushEnterKey();
				ReturnToTitle();
			}
			break;

			case STEP.GAME_OVER:
			{
				moveUnitychan.enabled = false;
				
				startText.guiText.text = null; // Not leave startText.
				
				GameObject gameoverText = GameObject.Find("GameOverText");
				gameoverText.guiText.text = "Game Over";
				DisplayTotalScore();
				
				DisplayPushEnterKey();
				ReturnToTitle();
			}
			break;

			case STEP.TIME_OVER:
			{
				moveUnitychan.enabled = false;
				anim.SetBool("Lose", true);
				
				GameObject timeoverText = GameObject.Find("TimeOverText");
				timeoverText.guiText.text = "Time Over";
				DisplayTotalScore();
				
				DisplayPushEnterKey();
				ReturnToTitle();
			}
			break;
		}





		DisplayPoint();
		DisplayTime();
	}


	void DisplayPoint()
	{
		GameObject obj = GameObject.Find("GetCountText");

		if(superballCounter < 10){
			obj.guiText.text = "Point:" + "0" + superballCounter;
		}
		else{
			obj.guiText.text = "Point:" + superballCounter;
		}
	}


	void ResetTime()
	{
		timeCounter = startTime;
	}

	void CountTime()
	{
		if(timePaused == true){
			return;
		}

		timeCounter -= Time.deltaTime;

		if(timeCounter <= 0.0f){
			timeCounter = 0.0f;
			timePaused = true;
		}
	}

	void DisplayTime()
	{
		GameObject obj = GameObject.Find("TimeLimitText");

		if(timeCounter < 10){
			obj.guiText.text = "Time:" + "0" + (int)timeCounter;
		}
		else{
			obj.guiText.text = "Time:" + (int)timeCounter;
		}

	}

	void DisplayTotalScore()
	{
		totalScore = (superballCounter * 500);

		if(step == STEP.GOAL){
			totalScore += ((int)timeCounter * 100);
		}

		GameObject obj = GameObject.Find("ScoreText");
		obj.guiText.text = "Score:" + totalScore;
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

	void ReturnToTitle(){
		if(Input.GetKeyDown(KeyCode.Return)){
			Application.LoadLevel("Title");
		}
	}
}
