//Adapted for use by Nathan Stowe
//Originally Created by SpeedTutor from this tutorial
//https://www.youtube.com/watch?v=tnA_4hJ70yg

//Fades in and fades out images on splash screen then switches to next scene

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SplashController : MonoBehaviour {

	public Image splashImage;

	IEnumerator Start(){
		splashImage.canvasRenderer.SetAlpha(0.0f);

		FadeIn ();
		yield return new WaitForSeconds (2.5f);
		FadeOut ();
		yield return new WaitForSeconds (2.5f);
		SceneManager.LoadScene (1);
	}

	void FadeIn(){
		splashImage.CrossFadeAlpha (1.0f, 1.5f, false);
	}

	void FadeOut(){
		splashImage.CrossFadeAlpha (0.0f, 1.5f, false);
	}

}
