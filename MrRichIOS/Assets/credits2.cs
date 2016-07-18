using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class credits2 : MonoBehaviour {

	public GameObject Credits;
	public GameObject mrRichCredits;
	public GameObject roseCredits;
	public GameObject infoButtonON;
	public GameObject infoButtonOFF;
	public GameObject shareButton;
	public GameObject playButton;
	public GameObject pauseBg;
	public GameObject gimmickStart;
	public GameObject gimmickShare;

	public void creditsOn() {

		Time.timeScale = 0f;
		infoButtonON.SetActive (false);
		shareButton.SetActive (false);
		playButton.SetActive (false);
		Credits.SetActive (true);
		mrRichCredits.SetActive (true);
		roseCredits.SetActive (true);
		infoButtonOFF.SetActive (true);
		pauseBg.SetActive (true);
		gimmickStart.SetActive (true);
		gimmickShare.SetActive (true);
	}

	public void creditsOff(){
		pauseBg.SetActive (false);
		infoButtonON.SetActive (true);
		shareButton.SetActive (true);
		playButton.SetActive (true);
		Credits.SetActive (false);
		mrRichCredits.SetActive (false);
		roseCredits.SetActive (false);
		infoButtonOFF.SetActive (false);
		gimmickStart.SetActive (false);
		gimmickShare.SetActive (false);

		Time.timeScale = 1f;

	}
}
