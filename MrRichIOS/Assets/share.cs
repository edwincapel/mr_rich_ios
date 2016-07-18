using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class share : MonoBehaviour {

	public GameObject pauseBg;
	public GameObject pauseBg2;
	public GameObject shareText;
	public GameObject facebookShareButton;
	public GameObject twitterShareButton;
	public GameObject backShareButton;
	public GameObject shareButton;
	public GameObject playButton;
	public GameObject infoButton;
	public GameObject gimmickStart;
	public GameObject gimmickInfo;


	public void shareOn(){

		Time.timeScale = 0f;
		playButton.SetActive (false);
		infoButton.SetActive (false);
		shareButton.SetActive (false);
		pauseBg2.SetActive (true);
		shareText.SetActive (true);
		facebookShareButton.SetActive (true);
		twitterShareButton.SetActive (true);
		backShareButton.SetActive (true);
		gimmickStart.SetActive (true);
		gimmickInfo.SetActive (true);

	}

	public void shareOff(){

		shareText.SetActive (false);
		gimmickStart.SetActive (false);
		gimmickInfo.SetActive (false);
		facebookShareButton.SetActive (false);
		twitterShareButton.SetActive (false);
		backShareButton.SetActive (false);
		pauseBg2.SetActive (false);
		playButton.SetActive (true);
		infoButton.SetActive (true);
		shareButton.SetActive (true);
		Time.timeScale = 1f;

	}
}
