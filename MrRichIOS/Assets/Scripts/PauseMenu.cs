using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public GameObject pauseBg;
	public GameObject pauseButton;
	public GameObject startButton;
	public GameObject restartButton;
	public GameObject homeButton;
	public GameObject scoreCounterButton;
	public GameObject settingsButton;
	public GameObject scoreBg;
	public GameObject highScore;
	public GameObject currentScore;
	public GameObject pausedText;


	public void pause(){
		pauseButton.SetActive (false);
		pauseBg.SetActive (true);
		startButton.SetActive (true);
		homeButton.SetActive (true);
		pausedText.SetActive (true);
		restartButton.SetActive (true);
		settingsButton.SetActive (true);
		scoreBg.SetActive(true);
		highScore.SetActive(true);
		currentScore.SetActive (true);
		scoreCounterButton.SetActive (false);
		Time.timeScale = 0f;
	}
	public void resume(){
		pausedText.SetActive (false);
		pauseBg.SetActive (false);
		startButton.SetActive (false);
		homeButton.SetActive (false);
		restartButton.SetActive (false);
		settingsButton.SetActive (false);
		scoreBg.SetActive(false);
		highScore.SetActive(false);
		currentScore.SetActive (false);
		pauseButton.SetActive (true);
		scoreCounterButton.SetActive (true);
		Time.timeScale = 1f;

	}
}
