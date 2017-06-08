//Created by Nathan Stowe

//Starts game when start button is pressed

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour {
	
	public Image menuBackground;
	public int currentLevel = 2; //player is on the first level, scene 2

	//public Button startButton;

	/*
	void Start (){
		Button btn = startButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}
	*/

	public void StartGame(){
		menuBackground.CrossFadeAlpha (0.0f, 1.5f, false);
		Invoke ("LoadGame", 2);

	}
	public void OpenOptions(){
		Debug.Log ("Opening Options");
	}

	public void ExitGame(){
		Application.Quit ();
	}

	void LoadGame(){
		SceneManager.LoadScene(currentLevel + 1); //scene number is current level of player and + 1 for menu/splash screens
	}


	/*
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

	void OnClick(){
		menuBackground.CrossFadeAlpha (0.0f, 1.5f, false);
		SceneManager.LoadScene(currentLevel + 1);
	}
	*/








}
