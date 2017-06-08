using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginOutro : MonoBehaviour {


	bool fov = false;

	void Update(){
		if(fov && GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ().fieldOfView < 178.0f){
			GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ().fieldOfView += 0.4f;
		}

	}

	void OnTriggerEnter(){
		GameObject.FindGameObjectWithTag ("Black Wall").GetComponent<MeshCollider> ().enabled = true;
		GameObject.FindGameObjectWithTag ("Player").GetComponent<AdvancedPlayerController> ().speed = 0.1f;
		GameObject.FindGameObjectWithTag ("Player").GetComponent<AdvancedPlayerController> ().jumpSpeed = 0.0f;
		fov = true;
		Invoke ("changeScene", 5.0f);
	}

	void changeScene(){
		SceneManager.LoadScene("Outro");

	}

}
