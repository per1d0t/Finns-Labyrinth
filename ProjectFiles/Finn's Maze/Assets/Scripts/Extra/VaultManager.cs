//VaultManager by Nathan Stowe
//This script(when attached to a hitbox) informs the player's animation controller
//whether or not they are able to use the fancy vault animation instead of a normal jumping animation
//To play the animation the player must be facing the object they wish to vault over, and running on the ground.

using UnityEngine;
using System.Collections;

public class VaultManager : MonoBehaviour{
    GameObject playerModel;

    GameObject player;
    AdvancedPlayerController playerController;

    int playerRotRange; //the amount of leeway given to the player when determining relative rotation to object being vaulted over

    Vector3 playerRot; //rotation of player(euler angles)
    Vector3 boxRot; //rotation of htibox this script is attached to(euler angles)

	// Use this for initialization
	void Start () {
        playerModel = GameObject.FindGameObjectWithTag("PlayerModel");

        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<AdvancedPlayerController>();

        playerRotRange = 30;		//Player must be within 30deg on either side of the perpendicular angle to the object
        playerRot = player.transform.rotation.eulerAngles;
        boxRot = transform.rotation.eulerAngles;
	}

    void OnTriggerStay(Collider other)
    {
        //ensures the range being compared will stay with in the degree scale (0 - 360) looping
        if (boxRot.x - playerRotRange < 0)
        {
            boxRot.x += 360;
        }
        if (boxRot.y - playerRotRange < 0)
        {
            boxRot.y += 360;
        }
        if (boxRot.z - playerRotRange < 0)
        {
            boxRot.z += 360;
        }

        //compares the players rotation to the hitbox's rotation.
        //If they are close enough, we will let the player vault as they are aligned to the obstacle properly
        if(
            playerRot.x >= boxRot.x - playerRotRange &&
            playerRot.x <= boxRot.x + playerRotRange &&

            playerRot.y >= boxRot.y - playerRotRange &&
            playerRot.y <= boxRot.y + playerRotRange &&

            playerRot.z >= boxRot.z - playerRotRange &&
            playerRot.z <= boxRot.z + playerRotRange
           )
        {
            //allow the player to vault
            playerController.canVault = true;
        }  
    }

    void OnTriggerExit(Collider other)
    { 
        //reset so that the player may vault again in the future
        playerController.canVault = false;
    }
}
