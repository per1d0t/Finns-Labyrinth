//PlayerHPManager
//by Nathan Stowe
//This script manages the players oxygen and overdose/health levels. It also changes the values of the acid shader
//depending on how much poison the player has ingested. When trips begin it also selects random parameters for that trip

using UnityEngine;
using System.Collections;

public class PlayerHPManager : MonoBehaviour {

	AcidTrip.AcidTrip acidFXScript; //player's acid Shader script

	//players O2 levels
	public float oxygen;
	public float oxygenDepletionRate;

	//players HP(overdose)
	public float overdose; 	//current hp/overdose
	float odRecoveryRate;	//rate it recovers
	float tolerance;		//max overdose limit before player dies

	//type of trip, is it sparkley??
	float tripType;
	float isSparkling;

	//target is what value in the FX shader we want, delta is how fast(per frame) we wanna get there
	float targetWaveFreq = 0.0f;
	float deltaWaveFreq = 0.0f;
	float targetDistortion = 0.0f;
	float deltaDistortion = 0.0f;

	// Use this for initialization
	void Start () {
		acidFXScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AcidTrip.AcidTrip>();

		oxygen = 420.0f;
		oxygenDepletionRate = 0.02f;

		overdose = 0.0f;
		odRecoveryRate = 0.01f;
		tolerance = 100.0f;

		tripType = Random.Range(0.0f, 1.0f);
		isSparkling = Random.Range(0.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		//if possible, lower oxygen
		if(oxygen > oxygenDepletionRate){
			oxygen -= oxygenDepletionRate;
		}

		//then manage OD levels and activity of acid shaders
		manageOverdoseFX ();
	}

	//if possible, lower overdose and ensure acid shaders are active
	//otherwise ensure acid shaders are disabled
	void manageOverdoseFX(){
		if(overdose > odRecoveryRate){
			overdose -= odRecoveryRate;

			if (!acidFXScript.enabled){
				acidFXScript.enabled = true;
			}

			//update "trip" intensity target based on Overdose
			targetWaveFreq = deltaWaveFreq * overdose;
			targetDistortion = deltaDistortion * overdose;


			//apply delta and change values
			//wave freq range: 0 - 12
			if(acidFXScript.Wavelength <= targetWaveFreq){
				acidFXScript.Wavelength += deltaWaveFreq;
			} else {
				acidFXScript.Wavelength -= deltaWaveFreq;
			}

			//distortion 0 - 12
			if(acidFXScript.DistortionStrength <= targetDistortion){
				acidFXScript.DistortionStrength += deltaDistortion;
			} else {
				acidFXScript.DistortionStrength -= deltaDistortion;
			}
				
			if(isSparkling <= 0.5f){
				acidFXScript.Sparkling = true;
			}else{
				acidFXScript.Sparkling = false;
			}

			//TODO:
			//default saturation (no effect) --> 1,0,0
			//sat base 1 - 80
			//sat speed 0 - 10
			//sat amp 0 - 8


		}else{
			if(acidFXScript.enabled){
				acidFXScript.enabled = false;
			}

			//reset rng so each trip is random
			tripType = Random.Range(0.0f, 1.0f);
			isSparkling = Random.Range(0.0f, 1.0f);

			//pick between high wavefreq or high distortion(cant have both)
			if(tripType >= 0.5f){
				print("trip1");
				deltaWaveFreq = 0.12f;
				deltaDistortion = 0.002f;

			}else{
				print("trip2");
				deltaWaveFreq = 0.002f;
				deltaDistortion = 0.12f;

			}
		}

		//kill player once they OD
		if(overdose >= tolerance){
			//TODO:kill player
		}
	}
}
