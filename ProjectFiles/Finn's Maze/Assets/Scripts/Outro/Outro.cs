//Adapted for use by Nathan Stowe
//Originally Created by SpeedTutor from this tutorial
//https://www.youtube.com/watch?v=tnA_4hJ70yg

//Fades in and fades out text on quote screen then switches to next scene

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Outro : MonoBehaviour {

	public Text splashText;

	IEnumerator Start(){
		splashText.canvasRenderer.SetAlpha(0.0f);

		FadeIn ();
		yield return new WaitForSeconds (2.5f);
		FadeOut ();
		yield return new WaitForSeconds (2.5f);
		splashText.text = "You are not yet ready.";
		FadeIn ();
		yield return new WaitForSeconds (2.5f);
		FadeOut ();
		yield return new WaitForSeconds (2.5f);
		Application.Quit();
	}

	void FadeIn(){
		splashText.CrossFadeAlpha (1.0f, 1.5f, false);
	}

	void FadeOut(){
		splashText.CrossFadeAlpha (0.0f, 1.5f, false);
	}

}
