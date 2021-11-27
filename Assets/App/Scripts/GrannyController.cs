using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GrannyController : MonoBehaviour
{
    public static GrannyController instance;

    [Header("Links")]
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent navAgent;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject granny;
    [SerializeField] private GameObject chair;
    [SerializeField] private AudioSource audioSource;

    private bool canAttack;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, granny.transform.position);
        animator.SetFloat("distance", distance);

        if (distance > 2.0f)
        {
            granny.transform.LookAt(player.transform);
        }

        if (ChristmasWhiteCoinManager.instance.SelectedWhiteCoin)
        {
            animator.SetBool("selectedWhiteCoin", true);
            animator.SetBool("selectedBlackCoin", false);
            navAgent.isStopped = true;
            chair.SetActive(false);

            ChristmasWhiteCoinManager.instance.SelectedWhiteCoin = false;
        }

        if (ChristmasBlackCoinManager.instance.SelectedBlackCoin)
        {
            navAgent.isStopped = false;
            navAgent.SetDestination(player.transform.position);

            animator.SetBool("selectedBlackCoin", true);
            animator.SetBool("selectedWhiteCoin", false);

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

            ChristmasBlackCoinManager.instance.SelectedBlackCoin = false;
        }
    }

}