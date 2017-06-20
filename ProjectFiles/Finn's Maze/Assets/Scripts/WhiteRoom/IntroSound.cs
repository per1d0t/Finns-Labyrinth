//IntroSound by Nathan Stowe
//This script plays the "Big Boom" sound at initialization

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AudioSource bigBoom = GetComponent<AudioSource>();
		bigBoom.Play();
	}

}
