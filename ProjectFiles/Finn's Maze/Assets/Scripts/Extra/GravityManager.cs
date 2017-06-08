//TODO:
    //-cleanup code by removing unnecessary variables, remove comments, comment code, format properly
    //-make it so that the rotations and position happen over time instead of instantly

using UnityEngine;
using System.Collections;

public class GravityManager : MonoBehaviour
{

    bool isRotating;
    // targetRot;
    Quaternion targetRot;
    Quaternion initialRot;
    Vector3 targetPos;
    Vector3 initialPos;

    //imported game objs
    GameObject world;
    GameObject player;
    GameObject camera;
    

    //imported components
    CharacterController playerController;
    CameraController playerCamControllerX;
    CameraController playerCamControllerY;
    BoxCollider gravityCollider;


    // Use this for initialization
    void Start()
    {
        //import game objects
        world = GameObject.FindGameObjectWithTag("World");
        player = GameObject.FindGameObjectWithTag("Player");
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        

        //import specific components of those objects
        playerController = player.GetComponentInChildren<CharacterController>();
        playerCamControllerX = player.GetComponentInChildren<CameraController>();
        playerCamControllerY = camera.GetComponentInChildren<CameraController>();
        gravityCollider = this.GetComponentInChildren<BoxCollider>();

        isRotating = false;
        //targetRot = transform.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        
        /*



        
        
        if(isRotating){
            //rotate world around player
            world.transform.rotation = Quaternion.Slerp(world.transform.rotation, targetRot, Time.deltaTime*25);

            
        }

        

        if (world.transform.rotation == targetRot) //we have finished rotating
        {
            isRotating = false;
            
            //enable player's movement controls and unfreezes them 
            playerController.enabled = true;

            //enable player's camera controls scripts:
            //(X)enable camera script attached to player object
            playerCamControllerX.enabled = true;
            //(Y)enable camera script attached to camera object
            playerCamControllerY.enabled = true;


            //pause for 2s then enable gravity collider
            Invoke("toggleCollisionBox", 2);
        }



        */

    }

    void OnTriggerEnter(Collider other)
    {
        initialRot = transform.rotation;


        print("initialRot" + initialRot);
        //print("initialPos" + initialPos);



        targetRot = player.transform.rotation; //the final destination of the box the script is attached to


        print("finalRot" + targetRot);
        print("finalPos" + targetPos);

        Vector3 rotDiff = (targetRot.eulerAngles - initialRot.eulerAngles); //the change in rotation we have to rotate by
        world.transform.rotation = Quaternion.Euler(world.transform.rotation.eulerAngles - rotDiff);
        initialPos = transform.position;
        targetPos = player.transform.position;
        world.transform.position += (targetPos - initialPos);

        toggleCollisionBox();
        //original
        /*
        print("gravity flippity flop entered");
        rotate = 1;
        //disable gravity beam hitbox
        */



        //redo//
        /*
        if(!isRotating){
            isRotating = true;
            
            //disable player's movement controls and freezes them in place
            playerController.enabled = false; 

            //disable player's camera controls scripts:
                //(X)disable camera script attached to player object
                playerCamControllerX.enabled = false;
                //(Y)disable camera script attached to camera object
                playerCamControllerY.enabled = false;

            toggleCollisionBox(); //immediatly turn off gravity collider
        }
        
    */

    }

    


    
    void toggleCollisionBox()
    {
        //toggles gravityCollider
        if (gravityCollider.enabled)
        {
            gravityCollider.enabled = false;
        }else
        {
            gravityCollider.enabled = true;
        }
        
    }
    







}
