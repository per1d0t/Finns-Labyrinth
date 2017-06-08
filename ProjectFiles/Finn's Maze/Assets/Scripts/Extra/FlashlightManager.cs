//FlashLightManager by Nathan Stowe
//This script(when attached to a hitbox) automatically enables the player's flashlight
//while in the hitbox, and disables it on exiting. The hitbox should be placed in dark areas, to represent darkness.

using UnityEngine;
using System.Collections;

public class FlashlightManager : MonoBehaviour {

    Light flashLight;

	void Start () {
        flashLight = GameObject.FindGameObjectWithTag("Flashlight").GetComponent<Light>();
	}

    void OnTriggerStay(Collider other)
    {
		//enable flashlight if hitbox is active
        if (flashLight.enabled == false)
        {
            flashLight.enabled = true;
        }

    }
		
    void OnTriggerExit(Collider other)
    {
		//disable flashlight after leaving hitbox
        flashLight.enabled = false;

    }
}
