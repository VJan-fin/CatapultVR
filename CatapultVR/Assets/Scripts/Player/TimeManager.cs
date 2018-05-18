using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour {

	public int MaxMinutes = 5;
	public TextMesh timerMesh;
    public AudioSource gameOverSoundEffect;

	private bool running;
	private float timeLeft; // in seconds
	private float startTime;

	private VoiceManager voiceManager;

	// Use this for initialization
	void Start () {
		startTime = 0.0f;
		running = false;
		timeLeft = MaxMinutes * 60.0f;
		voiceManager = GameObject.FindGameObjectWithTag ("PlayerManager").GetComponent<VoiceManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (running) {
			timeLeft = GetNewTimeLeft ();
			RenderTimeLeft ();
			HandleEnd ();
		}
	}

	public void StartGame() {
		Debug.Log ("start game");
		running = true;
		startTime = Time.time;
        voiceManager.RespawnCannonballs();
	}

	private float GetNewTimeLeft() {
		float elapsedTime = Time.time - startTime;
		return (MaxMinutes * 60.0f) - elapsedTime;
	}

	private void RenderTimeLeft() {
		string minutes = ((int)timeLeft / 60).ToString ();
		//string format = (timeLeft >= 60.0f) ? "f0" : "f1";
		string seconds = (timeLeft % 60).ToString ("f0");
        if(seconds.Length == 1) { seconds = "0" + seconds; }

		timerMesh.text = minutes + ":" + seconds;
	}

	private void HandleEnd (){
		if (timeLeft < 0) {
			running = false;
			timerMesh.text = "Game Over";
            timerMesh.transform.position += transform.up;
            gameOverSoundEffect.Play();
			voiceManager.RemoveCannonballs ();
			Invoke ("RestartLevel", 5.0f);
		}
	}

	private void RestartLevel() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
