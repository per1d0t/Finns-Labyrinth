//PoisonManager by Nathan Stowe
//This script is triggered when entering poison hitboxes and should be attached to a poison cloud object
//It basically just increases the player's overdose levels

using UnityEngine;
using System.Collections;

public class PoisonManager : MonoBehaviour
{

	PlayerHPManager playerHPScript; //player HP and O2 management script
	float poisonStrength;
    
	// Use this for initialization
	void Start () {
		playerHPScript = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerHPManager>();
		poisonStrength = 0.2f;
    }

	//if player is in poison field
    void OnTriggerStay(Collider other)
    {
        //if player is pretty much empty on o2, poison them alot, otherwise just a bit
		if(playerHPScript.oxygen <= playerHPScript.oxygenDepletionRate){
			playerHPScript.overdose += poisonStrength * 5;
		}else{
			playerHPScript.overdose += poisonStrength;
		}   
    }
}