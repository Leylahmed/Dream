using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // [Header("Parameters")]
    [SerializeField] private float moveSpeed;

    [SerializeField] private float walkSpeed;

    [SerializeField] private float runSpeed;

    [SerializeField] private bool isGrounded;

    [SerializeField] private float checkDistance;

    [SerializeField] private LayerMask groundMask;

    [SerializeField] private float gravity;

    [SerializeField] private Animator playerAnimator;

    [SerializeField] private AudioSource walkAudio;

    [SerializeField] private GameManager gameManager;
    //[Header("References")]
    private CharacterController controller;

    private Vector3 moveDirection;

    private Vector3 velocity;

    private Movement movement = Movement.IDLE;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        InvokeRepeating("ActiveDeactiveFootStepAudio", 0f, 0.5f);
    }
    void Update()
    {
        Move();
    }

    private void ActiveDeactiveFootStepAudio()
    {
        if (movement == Movement.IDLE)
        {
            walkAudio.Stop();
        }
        else
        {
            walkAudio.Play();
        }
    }
    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, checkDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float verticalInput = Input.GetAxis("Vertical");

        float horizontalInput = Input.GetAxis("Horizontal");


        moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;

        if (isGrounded)
        {
            playerAnimator.SetFloat("Horizontal", horizontalInput);
            playerAnimator.SetFloat("Vertical", verticalInput);
            transform.position = transform.position + (transform.forward * moveSpeed * Time.deltaTime);
            transform.position += (transform.forward * verticalInput + transform.right * horizontalInput) * Time.deltaTime * moveSpeed;
            
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                if (!gameManager.isPlayerInForest)
                {
                    walkSpeed = 1f;
                }
                else
                {
                    walkSpeed = 3f;
                }
                movement = Movement.WALK;
                moveSpeed = walkSpeed;
                playerAnimator.speed = 0.9f;


            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                if (!gameManager.isPlayerInForest)
                {
                    runSpeed = 2.5f;
                }
                else
                {
                    runSpeed = 6f;
                }
                movement = Movement.RUN;
                moveSpeed = runSpeed;
                playerAnimator.speed = 1.5f;

            }
            else if (moveDirection == Vector3.zero)
            {
                movement = Movement.IDLE;
                moveSpeed = 0f;
            }
            moveDirection *= moveSpeed;
        }

        controller.Move(moveDirection * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }



}
public enum Movement { IDLE, WALK, RUN }