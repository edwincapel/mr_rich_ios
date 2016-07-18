using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Application.LoadLevel(name);
		Time.timeScale = 1f;
	}

	public void QuitRequest(){
		Application.Quit();
	}
}
