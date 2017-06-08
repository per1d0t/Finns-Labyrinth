//PitfallScript by Nathan Stowe
//This scripts hitbox counts the number of times it is triggered by a player.
//Triggers 1 - 3 the hitbox fades camera and sound to black/0, then respawns player at beginning of level
//At trigger #4 the camera and sounds fade to black/0 and the scene is changed

//TODO:remake this script so that a random trip is picked in every switch statement
//the trip should use the screenFX attached to main camera, cameraFOV, and acidShader

using UnityEngine;
using System.Collections;

public class PitfallScript : MonoBehaviour {

	private int triggerNum;	//number of times scripts hitbox has been triggered
	private GameObject player;
	private GameObject playerCam;
	private bool cameraFadingOut;
	private bool cameraFadingIn;
	private float cameraOpacity;
	private float fadeTime;

	// Use this for initialization
	void Start () {
		triggerNum = -1;
		player = GameObject.FindGameObjectWithTag("Player");
		playerCam = GameObject.FindGameObjectWithTag("MainCamera");
		cameraFadingIn = false;
		cameraFadingOut = false;
		cameraOpacity = 100.0f;
		fadeTime = 10.0f;

	}

	// Update is called once per frame
	void Update () {
		if(cameraFadingIn){
			//TODO:fade in camera, should reach 100 in fadetime

			if (cameraOpacity > 99.0f) {
				cameraFadingIn = false;
			}
		}

		if(cameraFadingOut){
			//TODO:fade in camera, should reach 100 in fadetime

			if (cameraOpacity < 1.0f) {
				cameraFadingOut = false;
				cameraFadingIn = true;
			}
		}
	}

	void OnTriggerEnter(){
		triggerNum++;
		cameraFadingOut = true;

		switch (triggerNum) {
		case 0:
			Invoke ("trip1", fadeTime);
			break;
		case 1:
			Invoke("trip2", fadeTime);
			break;
		case 2:
			Invoke("trip3", fadeTime);
			break;
		case 3:
			Invoke("trip4", fadeTime);
			break;
		case 4:
			Invoke("trip5", fadeTime);
			break;
		}
	}

	void trip1(){
		//enable acid trip fx 1
		playerCam.GetComponent<UnityStandardAssets.ImageEffects.ScreenOverlay>().enabled = true;
		respawnPlayer();

	}

	void trip2(){
		//enable acid trip fx 2, (2 is an additive to 1)
		playerCam.GetComponent<UnityStandardAssets.ImageEffects.Twirl>().enabled = true;
		respawnPlayer();

	}

	void trip3(){
		//changed for demo version, maybe well get back to this and make this game the real deal



		//TODO:
		//disable acid trip fx 2(and 1)
		playerCam.GetComponent<UnityStandardAssets.ImageEffects.ScreenOverlay>().enabled = false;
		playerCam.GetComponent<UnityStandardAssets.ImageEffects.Twirl>().enabled = false;
		respawnPlayer();
		//enable acid trip fx 3
		GameObject.FindGameObjectWithTag ("Outro Wall").GetComponent<BoxCollider> ().enabled = true;
		GameObject.FindGameObjectWithTag ("Wall Trigger").GetComponent<BoxCollider> ().enabled = true;
		GameObject.FindGameObjectWithTag ("Black Wall").GetComponent<MeshRenderer> ().enabled = true;

	}

	void trip4(){
		//TODO:
		//disable acid trip fx 3
		respawnPlayer();

		//enable acid trip fx 4
	}

	void trip5(){
		//TODO:
		//disable acid trip fx 4
		//change scenes to cave
	}

	void respawnPlayer(){
		//teleport to spawn
		player.transform.position = new Vector3(0.14f, 0.6f, -36.5f);
		player.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
	}
}
