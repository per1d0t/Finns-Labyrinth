//CaveGlow
//by Nathan Stowe
//This script spawns floating cube particles with a slowly brightening light and moves them around the cave.
//It also enables the character controller after a short time

using UnityEngine;
using System.Collections;

public class CaveGlow : MonoBehaviour {

	GameObject[] flyingCubes;	//array to hold all the cubes
	int numCubes;	//number of total cubes
	Vector3[] speeds; //cube speeds
	public Material rainbow; //cube material

	//x and y scale for texture on material
	float scaleX;
	float scaleY;

	GameObject player;
	AdvancedPlayerController playercontroller;

	void Start(){
		numCubes = 20;
		flyingCubes = new GameObject[numCubes];
		speeds = new Vector3[20];

		player = GameObject.FindGameObjectWithTag("Player");
		playercontroller = player.GetComponent<AdvancedPlayerController>();

		//spawn cubes
		for(int i = 0; i < numCubes; i++){
			speeds[i] =new Vector3(Random.Range(0.04f, 0.1f), Random.Range(0.1f, 0.4f), Random.Range(0.04f, 0.1f));
			flyingCubes[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);

			//remove colliders from cubes
			flyingCubes[i].GetComponent<Collider>().enabled = false;

			//add point lights to cubes
			flyingCubes[i].AddComponent<Light>();
			flyingCubes[i].GetComponent<Light>().intensity = 3.4f;
			flyingCubes[i].GetComponent<Light>().bounceIntensity = 0;
			flyingCubes[i].GetComponent<Light>().range = 10;

			//TODO:pick spawns for cave
			//spawn cubes in position
			flyingCubes[i].transform.position = new Vector3(172 + Random.Range(-5.0f, 5f), -29 + Random.Range(-5.0f, 5f), 43 + Random.Range(-5.0f, 5f));

			//TODO:change scale
			//flyingCubes[i].transform.scale = new Vector3(0.3f, 0.3f, 0.3f);

			//TODO:change rotation

			((Renderer)(flyingCubes[i].GetComponent("Renderer"))).material = rainbow;

			//assign materials to groups of 5 and add glows to cubes
			int materialNum = i % 5;
			switch(materialNum){
			case 0:
				flyingCubes[i].GetComponent<Light>().color = Color.blue;
				((Renderer)(flyingCubes [i].GetComponent ("Renderer"))).material.mainTextureScale = new Vector2 (0.1f, 1);
				break;
			case 1:
				flyingCubes[i].GetComponent<Light>().color = Color.cyan;
				((Renderer)(flyingCubes [i].GetComponent ("Renderer"))).material.mainTextureScale = new Vector2 (0, 1);
				break;
			case 2:
				flyingCubes[i].GetComponent<Light>().color = Color.magenta;
				((Renderer)(flyingCubes [i].GetComponent ("Renderer"))).material.mainTextureScale = new Vector2 (-0.06f, 1.48f);
				break;
			case 3:
				flyingCubes[i].GetComponent<Light>().color = Color.green;
				((Renderer)(flyingCubes [i].GetComponent ("Renderer"))).material.mainTextureScale = new Vector2 (0.1f, -1.19f);
				break;
			case 4:
				flyingCubes[i].GetComponent<Light>().color = Color.yellow;
				((Renderer)(flyingCubes [i].GetComponent ("Renderer"))).material.mainTextureScale = new Vector2 (-0.06f, -0.23f);
				break;
			}


		}

		//TODO:invoke activate player after x seconds

	}




	void Update(){
		for(int i = 0; i < numCubes; i++){
			//move cubes
			flyingCubes[i].transform.position += new Vector3(speeds[i].x, speeds[i].y, speeds[i].z);
		}
	}

	//activate player controller
	void ActivatePlayer(){
		//TODO:activate the player script
	}
}
