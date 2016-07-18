using Facebook.Unity;
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public AudioClip coinSound;
	public Text scoreText;
	public Text highScoreText;
	public Text currentScore;
	public GameObject EnemyPrefab;
	public GameObject money;
	public int moneyValue;
	public static int score;
	public int highScore;
	public float currentScale = 0.5f;
	public string fileNameShare;
	string ScoreText;


	public void TweetLove(){

		int unicode = 10084;
		char character = (char) unicode;
		string text = character.ToString();

		string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
		string TWEET_LANGUAGE = "en";

		Application.OpenURL(TWITTER_ADDRESS +
			"?text=" + WWW.EscapeURL("I " + text + " Mr Rich !" + "\nDownload Mr Rich from the appstore now !  \n\nhttp://mrrichthega.me/\nhttp://gph.is/1MIkOaI")) ;

	}

	public void ShareLoveFb()
	{

		int unicode = 10084;
		char character = (char) unicode;
		string text = character.ToString();
		string fullText = "I " + text + " Mr Rich !";

		FB.FeedShare (
			string.Empty,
			new Uri("http://mrrichthega.me/"),
			fullText,
			"Download this game and beat my highscore !",
			"Help Mr.Rich gain his wealth now",	new Uri("http://i.imgur.com/NiJpVsU.jpg"),
			string.Empty,
			ShareCallback
		);
	}

	public void Reset(){

		score = 0;
	}

	void Awake ()
	{
		if (FB.IsInitialized) {
			FB.ActivateApp();
		} else {
			//Handle FB.Init
			FB.Init( () => {
				FB.ActivateApp();
			});
		}
	}

	void OnApplicationPause (bool pauseStatus)
	{
		// Check the pauseStatus to see if we are in the foreground
		// or background
		if (!pauseStatus) {
			//app resume
			if (FB.IsInitialized) {
				FB.ActivateApp();
			} else {
				//Handle FB.Init
				FB.Init( () => {
					FB.ActivateApp();
				});
			}
		}
	}


	public void Share()
	{

		highScore = PlayerPrefs.GetInt("HighScore");
		int currentScore2 = score;
		if (currentScore2 > highScore) {

			ScoreText = "I just made a New high score of " + PlayerPrefs.GetInt ("HighScore") + " !";

		} 
		else if (currentScore2 == highScore) {
			ScoreText = "So Close ! Almost beat my own highscore of " + PlayerPrefs.GetInt ("HighScore") + " !";

		}else if (currentScore2 > 0) {
			ScoreText = "I just scored " + currentScore2 + " and my high score is " + PlayerPrefs.GetInt ("HighScore") + " !";

		} else {
			ScoreText = "My high score is " + PlayerPrefs.GetInt ("HighScore") + " ! Try and beat me !";
		}

		FB.FeedShare (
			string.Empty,
			new Uri("http://mrrichthega.me/"),
			ScoreText,
			"Download this game and beat my highscore !",
			"Help Mr.Rich gain his wealth now",	new Uri("http://i.imgur.com/NiJpVsU.jpg"),
			string.Empty,
			ShareCallback
		);
	}

	void ShareCallback (IResult result)
	{
		if (result.Cancelled) {
			Debug.Log ("Share Cancelled");
		} else if (!string.IsNullOrEmpty (result.Error)) {
			Debug.Log ("Error on share!");
		} else if (!string.IsNullOrEmpty (result.RawResult)) {
			Debug.Log ("Success on share");
		}
	}

	// Use this for initialization
	void Start () {
		EnemyPrefab.GetComponent<Rigidbody2D>().gravityScale = currentScale;
		money.GetComponent<Rigidbody2D>().gravityScale = currentScale;
		UpdateScore ();
		if(PlayerPrefs.HasKey("HighScore")){
			highScore = PlayerPrefs.GetInt("HighScore");
			highScoreText.text = "" + highScore;
		}
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.name == "moneymo" || col.gameObject.name == "moneymo(Clone)") {
			AudioSource.PlayClipAtPoint (coinSound, transform.position);
			score += moneyValue;
			UpdateScore ();
		}

	}

	void UpdateScore(){
		scoreText.text = "" + score;
		currentScore.text = "" + score;
		if (score > highScore) {
			highScore = score;
			highScoreText.text = "" + highScore;
			PlayerPrefs.SetInt ("HighScore", highScore);
		}
		if (score >= 10 && score<=20) {
			currentScale = 0.7f;
			EnemyPrefab.GetComponent<Rigidbody2D>().gravityScale = currentScale;
			money.GetComponent<Rigidbody2D>().gravityScale = currentScale;
		}
		else if (score >= 21 && score<=30) {
			currentScale = 0.9f;
			EnemyPrefab.GetComponent<Rigidbody2D>().gravityScale = currentScale;
			money.GetComponent<Rigidbody2D>().gravityScale = currentScale;
		}
		else if (score >= 31 && score<=1000) {
			currentScale = 1.1f;
			EnemyPrefab.GetComponent<Rigidbody2D>().gravityScale = currentScale;
			money.GetComponent<Rigidbody2D>().gravityScale = currentScale;
		}

	}
}
