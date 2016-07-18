using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;

public class GameController : MonoBehaviour {

	private BannerView bannerView;
	private InterstitialAd interstitial;
	public GameObject restartButton;
	public GameObject bgShare;
	public GameObject number;
	public GameObject money;
	public GameObject angry;
	public GameObject money2;
	public GameObject angry2;
	public GameObject countDown;
	public GameObject front1;
	public GameObject highScore;
	public GameObject currentScore;
	public GameObject pauseButton;
	public GameObject homeButton;
	public GameObject tintBg;
	public GameObject scoreBoardbg;
	public GameObject GameOver;
	public GameObject tutorial;
	public GameObject roseTutorial;
	public GameObject moneyTutorial;
	public GameObject textTutorial;
	public GameObject pauseBg;
	public GameObject startButton;
	public GameObject pausedText;
	public GameObject settingsButton;
	public GameObject scoreBg;
	public GameObject scoreCounterButton;
	public GameObject shareOn;
	public GameObject shareOff;
	public GameObject shareText;
	public GameObject twitterButton;
	public GameObject fbShare;
	public GameObject gimmickRestart;
	public GameObject gimmickHome;
	public GameObject LeftButton;
	public GameObject RightButton;
	public Text timerText;
	private int counter =0;
	private float counter2;
	public float timeLeft;
	private float deltaTime = 0.0f;
	int adCounter =0;

	private Score score;

	public void shareSceneOn(){
		tintBg.SetActive (false);
		bgShare.SetActive (true);
		highScore.SetActive (false);
		currentScore.SetActive (false);
		restartButton.SetActive (false);
		homeButton.SetActive (false);
		fbShare.SetActive (true);
		scoreBoardbg.SetActive (false);
		GameOver.SetActive (false);
		shareOn.SetActive (false);
		shareOff.SetActive (true);
		shareText.SetActive (true);
		twitterButton.SetActive (true);
		gimmickRestart.SetActive (true);
		gimmickHome.SetActive (true);
	}

	public void shareSceneOff(){
		tintBg.SetActive (true);
		bgShare.SetActive (false);
		highScore.SetActive (true);
		currentScore.SetActive (true);
		restartButton.SetActive (true);
		homeButton.SetActive (true);
		fbShare.SetActive (false);
		scoreBoardbg.SetActive (true);
		GameOver.SetActive (true);
		shareOn.SetActive (true);
		shareOff.SetActive (false);
		shareText.SetActive (false);
		twitterButton.SetActive (false);
		gimmickRestart.SetActive (false);
		gimmickHome.SetActive (false);
	}

	public void home(){
		Application.LoadLevel("Start");
		Time.timeScale = 1f;
		bannerView.Destroy ();
	}

	public void pause(){
		LeftButton.SetActive (false);
		RightButton.SetActive(false);
		pauseButton.SetActive (false);
		pauseBg.SetActive (true);
		startButton.SetActive (true);
		//homeButton.SetActive (true);
		pausedText.SetActive (true);
		//restartButton.SetActive (true);
		//settingsButton.SetActive (true);
		scoreBg.SetActive(true);
		highScore.SetActive(true);
		currentScore.SetActive (true);
		scoreCounterButton.SetActive (false);
		Time.timeScale = 0f;
	}

	public void resume(){
		LeftButton.SetActive (true);
		RightButton.SetActive(true);
		pausedText.SetActive (false);
		pauseBg.SetActive (false);
		startButton.SetActive (false);
		//homeButton.SetActive (false);
		//restartButton.SetActive (false);
		//settingsButton.SetActive (false);
		scoreBg.SetActive(false);
		highScore.SetActive(false);
		currentScore.SetActive (false);
		pauseButton.SetActive (true);
		scoreCounterButton.SetActive (true);
		Time.timeScale = 1f;

	}

	void Start () {
		StartCoroutine(Spawn ());
		Time.timeScale = 1f;
	}

	void Update()
	{
		// Calculate simple moving average for time to render screen. 0.1 factor used as smoothing
		// value.
		deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
	}

	void FixedUpdate(){
		
		timeLeft -= Time.deltaTime;
		tintBg.SetActive (true);
		if (timeLeft < 0) {
			timeLeft = 0;
			tintBg.SetActive (false);
			countDown.SetActive (false);
			tutorial.SetActive (false);
			roseTutorial.SetActive (false);
			moneyTutorial.SetActive (false);
			textTutorial.SetActive (false);
			pauseButton.SetActive (true);
		}
		UpdateText ();
	}

	void UpdateText(){
		timerText.text = ""+ Mathf.RoundToInt (timeLeft);
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.name == "angry" || col.gameObject.name == "angry(Clone)") {
			counter += 2;
		}
	}

	IEnumerator Spawn(){
		RequestBanner ();
		RequestInterstitial();
		yield return new WaitForSeconds (3.0f);
		yield return new WaitForSeconds (0.1f);
		bannerView.Show ();
		number.SetActive (true);
		front1.SetActive (true);
		LeftButton.SetActive (true);
		RightButton.SetActive(true);


		while (counter <1) {


			Vector3 playerSize = GetComponent<Renderer>().bounds.size;

			// Here is the definition of the boundary in world point
			var distance = (transform.position - Camera.main.transform.position).z;

			var leftBorder = (Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance)).x + (playerSize.x/2))-0.5f;
			var rightBorder = (Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance)).x - (playerSize.x/2))+0.7f;

			var money1 = UnityEngine.Random.Range (leftBorder, rightBorder);
			var ros1 = UnityEngine.Random.Range (leftBorder, rightBorder);
			var money2 = UnityEngine.Random.Range (leftBorder, rightBorder);
			var ros2 = UnityEngine.Random.Range (leftBorder, rightBorder);

			if (money2 == money1 || money2 == ros1) {

				while (money2 == money1 || money2 == ros1) {

					money2 = UnityEngine.Random.Range (leftBorder, rightBorder);

				}
			}

			if (ros2 == money1 || ros2 == ros1) {

				while (ros2 == money1 || ros2 == ros1) {

					ros2 = UnityEngine.Random.Range (leftBorder, rightBorder);

				}
			}

			counter2 = UnityEngine.Random.Range (1, 3);
			Debug.Log (Score.score);
			if (counter2 == 1) {
				Vector3 spawnPosition = new Vector3 (money1, 7, -5);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (angry, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (0.3f);
				if (Score.score>30) {
					Vector3 spawnPosition2 = new Vector3 (ros2, 7, -5);
					Quaternion spawnRotation2 = Quaternion.identity;
					Instantiate (angry, spawnPosition2, spawnRotation2);
					yield return new WaitForSeconds (0.3f);

				}
			} else if(counter2 == 2){
				Vector3 spawnPosition = new Vector3 (ros1, 7, -5);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (money, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (0.3f);
				if (Score.score>30) {
					Vector3 spawnPosition2 = new Vector3 (money2, 7, -5);
					Quaternion spawnRotation2 = Quaternion.identity;
					Instantiate (angry, spawnPosition2, spawnRotation2);
					yield return new WaitForSeconds (0.3f);

				}
			}

		}
		Time.timeScale = 0f;
		LeftButton.SetActive (false);
		RightButton.SetActive(false);
		number.SetActive (false);
		pauseButton.SetActive (false);
		front1.SetActive (false);
		tintBg.SetActive (true);
		highScore.SetActive (true);
		currentScore.SetActive (true);
		restartButton.SetActive (true);
		homeButton.SetActive (true);
		shareOn.SetActive (true);
		scoreBoardbg.SetActive (true);
		GameOver.SetActive (true);

		adCounter = UnityEngine.Random.Range (1, 6);

		if (adCounter == 1 || adCounter == 2 || adCounter == 3 || adCounter == 4) {
			Debug.Log ("edwin");
			bannerView.Destroy ();

		} else if (adCounter == 5) {
			ShowInterstitial ();
			bannerView.Destroy ();
		}
			
	}

	void Awake(){
		angry.SetActive (true);
		money.SetActive (true);
	}

	private void RequestBanner()
	{
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "INSERT_ANDROID_BANNER_AD_UNIT_ID_HERE";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-6404058195322804/9458650573";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
		// Register for ad events.
		bannerView.OnAdLoaded += HandleAdLoaded;
		bannerView.OnAdFailedToLoad += HandleAdFailedToLoad;
		bannerView.OnAdLoaded += HandleAdOpened;
		bannerView.OnAdClosed += HandleAdClosed;
		bannerView.OnAdLeavingApplication += HandleAdLeftApplication;
		// Load a banner ad.
		bannerView.LoadAd(createAdRequest());
		}

		private void RequestInterstitial()
		{
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "INSERT_ANDROID_INTERSTITIAL_AD_UNIT_ID_HERE";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-6404058195322804/1935383771";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create an interstitial.
		interstitial = new InterstitialAd(adUnitId);
		// Register for ad events.
		interstitial.OnAdLoaded += HandleInterstitialLoaded;
		interstitial.OnAdFailedToLoad += HandleInterstitialFailedToLoad;
		interstitial.OnAdOpening += HandleInterstitialOpened;
		interstitial.OnAdClosed += HandleInterstitialClosed;
		interstitial.OnAdLeavingApplication += HandleInterstitialLeftApplication;
		// Load an interstitial ad.
		interstitial.LoadAd(createAdRequest());
		}

		// Returns an ad request with custom ad targeting.
		private AdRequest createAdRequest()
		{
		return new AdRequest.Builder()
		.AddTestDevice(AdRequest.TestDeviceSimulator)
		.AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
		.AddKeyword("game")
		.SetGender(Gender.Male)
		.SetBirthday(new DateTime(1985, 1, 1))
		.TagForChildDirectedTreatment(false)
		.AddExtra("color_bg", "9B30FF")
		.Build();
		}


		private void ShowInterstitial()
		{
		if (interstitial.IsLoaded())
		{
		interstitial.Show();
		}
		else
		{
		print("Interstitial is not ready yet.");
		}
		}
		#region Banner callback handlers

		public void HandleAdLoaded(object sender, EventArgs args)
		{
		print("HandleAdLoaded event received.");
		}

		public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
		{
		print("HandleFailedToReceiveAd event received with message: " + args.Message);
		}

		public void HandleAdOpened(object sender, EventArgs args)
		{
		print("HandleAdOpened event received");
		}

		void HandleAdClosing(object sender, EventArgs args)
		{
		print("HandleAdClosing event received");
		}

		public void HandleAdClosed(object sender, EventArgs args)
		{
		print("HandleAdClosed event received");
		}

		public void HandleAdLeftApplication(object sender, EventArgs args)
		{
		print("HandleAdLeftApplication event received");
		}

		#endregion

		#region Interstitial callback handlers

		public void HandleInterstitialLoaded(object sender, EventArgs args)
		{
		print("HandleInterstitialLoaded event received.");
		}

		public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
		{
		print("HandleInterstitialFailedToLoad event received with message: " + args.Message);
		}

		public void HandleInterstitialOpened(object sender, EventArgs args)
		{
		print("HandleInterstitialOpened event received");
		}

		void HandleInterstitialClosing(object sender, EventArgs args)
		{
		print("HandleInterstitialClosing event received");
		}

		public void HandleInterstitialClosed(object sender, EventArgs args)
		{
		print("HandleInterstitialClosed event received");
		}

		public void HandleInterstitialLeftApplication(object sender, EventArgs args)
		{
		print("HandleInterstitialLeftApplication event received");
		}

		#endregion


}
