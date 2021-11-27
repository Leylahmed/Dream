using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyselfController : MonoBehaviour
{

    [SerializeField] private LayerMask groundMask;

    [SerializeField] private float gravity;

    [SerializeField] private bool isGrounded;

    [SerializeField] private float checkDistance;

    [SerializeField] private ParticleSystem teleportEffect;

    [SerializeField] private GameObject player;

    [SerializeField] private Animator myselfAnimator;

    [SerializeField] private GameObject winCanvas;

    private CharacterController controller;

    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        teleportEffect.Play();

    }
    void Update()
    {
        CheckDistance();

        if (Vector3.Distance(player.transform.position, transform.position) > 2)
        {
            transform.LookAt(player.transform);
        }

    }

    private void CheckDistance()
    {
        isGrounded = Physics.CheckSphere(transform.position, checkDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("trigger enter");
            myselfAnimator.SetBool("isIdle", true);

            UnityEngine.Cursor.lockState = CursorLockMode.None;
            winCanvas.SetActive(true);
        }
    }

   

}
