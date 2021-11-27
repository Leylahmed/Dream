using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MadhatterController : MonoBehaviour
{
    public static MadhatterController instance;

    [Header("Links")]
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent navAgent;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject madHatter;
    [SerializeField] private AudioSource audioSource;

    private bool canAttack;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, madHatter.transform.position);
        animator.SetFloat("distance", distance);

        if (distance > 2.0f)
        {
            madHatter.transform.LookAt(player.transform);
        }

        if (MushroomsWhiteCoinManager.instance.SelectedWhiteCoin)
        {
            animator.SetBool("selectedWhiteCoin", true);
            animator.SetBool("selectedBlackCoin", false);
            navAgent.isStopped = true;

            MushroomsWhiteCoinManager.instance.SelectedWhiteCoin = false;
        }

        if (MushroomsBlackCoinManager.instance.SelectedBlackCoin)
        {
            animator.SetBool("selectedBlackCoin", true);
            animator.SetBool("selectedWhiteCoin", false);
            navAgent.isStopped = false;
            navAgent.SetDestination(player.transform.position);

            canAttack = true;


        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && canAttack )
        {
            navAgent.isStopped = true;
            audioSource.Play();
            GameManager.gameManager.GameOver(false);

            canAttack = false;

            MushroomsBlackCoinManager.instance.SelectedBlackCoin = false;
        }
    }

}