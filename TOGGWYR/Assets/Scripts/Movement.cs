using System.Collections;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 1300.5f; //general speed modifier jumping and running
    public float jumpSpeed = 20.0f; //equal to jump height
    public float gravity = 20.0f;

    public GameObject Player;
    public Vector3 rot = Vector3.zero;
    
    private Vector3 moveDirection = Vector3.zero;

    public Animator anim;
    private Animator _animator;

    private int justmoved = 0;
    Vector3 dir = Vector3.zero;
    public Button JumpButton;
    private int rangecheck = 0; //counter for userinputcalculation
    private float[] rangeData = new float[3]; //vectorsize is equal to number of frames being analized for user input

    void Start()
    {
        _animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();

        Button jmp = JumpButton.GetComponent<Button>();
        jmp.onClick.AddListener(Jump);
    }

    void Update()
    {
        //Debug.Log(Player.transform.position.y);
        //characterContoller.isGrounded
        if (Player.transform.position.y < 0.5)
        {
            //print("TOGWYR: " + globals.tilt);
            if (!globals.tilt)
            {
                CheckForAccelerationInput();
                if (Input.acceleration.z > 0.7)
                {
                    Jump();
                } 
                
                /*
            print("TOGWYR" + justmoved);
            if (Input.acceleration.x > 0.8 && justmoved == 0)
            {
                moveleft();
                justmoved = 3;
            } else if (Input.acceleration.x < -0.8 && justmoved == 0)
            {
                moveright();
                justmoved = 3;
            }
            */
            }
            else
            {
                dir.z = Input.acceleration.x;

            }

            // clamp acceleration vector to the unit sphere
            if (dir.sqrMagnitude > 1)
                dir.Normalize();
    
            // Make it move 10 meters per second instead of 10 meters per frame...
            dir *= Time.deltaTime;
            
            // We are grounded, so recalculate
            // move direction directly from axes
            moveDirection = new Vector3(-1.0f, 0.0f, 0.0f);
            
            //make the player get faster and faster
            moveDirection.x = -1.0f - globals.score * 0.05f;
            if (moveDirection.x < -5)
            {
                moveDirection.x = -5.0f;
            }
            
            //applying general speed modifier
            moveDirection *= speed;
            
            //jump if
            if (Input.GetButton("Jump"))
            {
                Jump();
            }

            moveDirection.z = dir.z * 700 ;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }
    void Jump()
    {
        print("JUMP before");
        if (Player.transform.position.y < 0.5)
        {
            print("JUMP 222");
            FindObjectOfType<SoundManager>().PlaySound("Jump");
            _animator.SetTrigger("jumping");
            moveDirection.y = jumpSpeed;
            //Rotion is countering the rotation of the character movement animation
            Player.transform.rotation = Quaternion.Euler(0, -90, 0);
            moveDirection.y -= gravity * Time.deltaTime;
            characterController.Move(moveDirection * Time.deltaTime);
        }
    }

    void CheckForAccelerationInput()
    {
        /*
        if (justmoved > 0)
        {
            justmoved--;    
        }
        */
        
        rangeData[rangecheck] = Input.acceleration.x;
        rangecheck++;
        if (rangecheck == rangeData.Length)
        {
            float min = 0.0f;
            float max = 0.0f;
            for (int i = 0; i < rangeData.Length; i++)
            {
                if (rangeData[i] < 0)
                {
                    min = -rangeData[i];
                }
                else
                {
                    max = rangeData[i];
                }
            }

            if (max > 0.7 || min > 0.7)
            {
                if (min > max)
                {
                    moveleft();
                }
                else
                {
                    moveright();
                }   
            }
            rangecheck = 0;
        }
        
    }

    void moveleft()
    {
        dir.z = 6;
    }

    void moveright()
    {
        dir.z = -6;
    }
} 