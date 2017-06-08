//TimeManager by Nathan Stowe
//This script(when attached to a hitbox), makes the entire game slow motion 
//untill the player or object leaves the hitbox.

using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {

	float slowMoTimeScale;		//represents the slowMo time's speed, relative to 1.0(normal). So 0.5 would be 50% speed

	void Start(){
		slowMoTimeScale = 0.2f;	//20% speed
	}

    void OnTriggerEnter(Collider other)
    {
        if (Time.timeScale == 1.0F)
        {
			Time.timeScale = slowMoTimeScale;
        }

    }

    void OnTriggerExit(Collider other)
    {
		//revert to default timescale(1.0)
        Time.timeScale = 1.0F;

    }
}
