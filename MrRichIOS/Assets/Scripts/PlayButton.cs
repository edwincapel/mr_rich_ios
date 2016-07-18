using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	public Texture2D icon;

	void OnGUI(){
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(20,40,80,20), new GUIContent("This is text", icon))) {
			Application.LoadLevel("Level_01");
		}

	}
}
