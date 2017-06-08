using UnityEngine;
using System.Collections;

public class AdvancedPlayerController : MonoBehaviour
{
    //static Animator anim;
    static CharacterController controller;

    public float speed;
    public float jumpSpeed;
    public float gravity;
    public CameraController cameraX;
    public bool canVault;
	public bool canMove;
    public float overdose;
    
    public AudioSource[] audioSourceList;

    private Vector3 moveDirection;
    private float slidingHeight;  //height of player during a slide
    private float footstepAudioDelay;
	private float terminalVelocity;

    void Start()
    {
        
        //anim = this.GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        cameraX = this.GetComponent<CameraController>();
        audioSourceList = this.GetComponents<AudioSource>();

        moveDirection = Vector3.zero;
        canVault = false;
		canMove = true;
        jumpSpeed = 5.0f;
        gravity = 9.81f;
        speed = 9.7f;
        overdose = 0.0f;
       
        slidingHeight = 1.0f;
        footstepAudioDelay = 0.0f;
		terminalVelocity = 1000.0f;
    }

    void Update()
    {
        
        footstepAudioDelay++;

        //if the player is on the ground and they can move
        if (controller.isGrounded && canMove)
        {
			//if they are feeding movement inputs to the playercontroller
            if (Input.GetAxis("LAnalog X") > 0.1 || Input.GetAxis("LAnalog Y") > 0.1 || Input.GetAxis("Keyboard Strafe") > 0.1 || Input.GetAxis("Keyboard Run") > 0.1)
            {
                run();
            }
            else
            {
                //player is idling, so ensure they are at default height and they aren't making footstep noises
				resetPlayer();
                footstepAudioDelay = 0.0f;
            }

            //Feed moveDirection with input. This must be done even when idle
            moveDirection = new Vector3(Input.GetAxis("LAnalog X") + Input.GetAxis("Keyboard Strafe"), 0, Input.GetAxis("LAnalog Y") + Input.GetAxis("Keyboard Run"));
            moveDirection = transform.TransformDirection(moveDirection);

            //Multiply it by speed.
            moveDirection *= speed;

            //Jumping
            if (Input.GetButton("Keyboard Jump") || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                jump();
            }

            //Sliding
            if (Input.GetButton("Keyboard Slide") || Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                slide();
            }
        }
        else
        {
            //Controller is not on ground, so we need to apply gravity to the controller
			if (moveDirection.y > -terminalVelocity) { //if we havn't hit terminal velocity
				
				moveDirection.y -= gravity * Time.deltaTime;
			} else {
				print("terminal v");
			}
           
            //anim.SetInteger("fallTime", anim.GetInteger("fallTime") + 1);
        }

        //Making the character move
        controller.Move(moveDirection * Time.deltaTime);
    }

    //causes player to jump, plays jumping anim
    void jump()
    {
        audioSourceList[0].Play(); //play jump sound
        moveDirection.y = jumpSpeed;
        Invoke("resetPlayer", 1.5f); //TODO: align the second parameter with length of slide/jump anims

		/*
        if (canVault)
        {
            anim.SetTrigger("isVaulting");
        }
        else
        {
            anim.SetTrigger("isJumping");
        }
        */
    }

    //causes player to slide, plays sliding anim
    void slide()
    {
        cameraX.enabled = false; //disable camera script that controls x movement

        controller.height = slidingHeight; //shorten player so they can slide under stuff
        Invoke("resetPlayer", 1.5f); //TODO: align the second parameter(seconds) with length of slide/jump anims
        //anim.SetTrigger("isSliding");
    }

    //Play's footstep soundFX loop
	//deprecated:notifies controller if player is running, plays running anim
    void run()
    {
		/*
        //reset triggers, player height
        anim.ResetTrigger("isSliding");
        anim.ResetTrigger("isJumping");
        anim.ResetTrigger("isVaulting");

        //begins running anim
        anim.SetBool("isRunning", true);
		*/

        //running sounds
        if (footstepAudioDelay > 40.0f)
        {
            audioSourceList[1].Play();
            audioSourceList[2].PlayDelayed(0.33f);
            footstepAudioDelay = 0.0f;
        }
    }


    //this resets player variables so they can continue controlling char after animations complete
    void resetPlayer()
    {
        cameraX.enabled = true;
        controller.height = 2.0f;
    }

    
}