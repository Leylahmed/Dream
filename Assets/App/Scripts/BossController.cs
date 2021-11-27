using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    [SerializeField] private PlayerController instance;

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject boss;

    [SerializeField] private Animator bossAnimator;

    [SerializeField] private GameManager gameManager;

    [SerializeField] private AudioSource bossIsComingSound;

    [SerializeField] private AudioSource bossIsAttackingSound;

    [SerializeField] private GameObject blackCanvas;

    public bool isBossCameraActive;

    private NavMeshAgent agentBoss;

    public bool isBossDead;

    private BossStates state = BossStates.IDLE;
    void Start()
    {
        agentBoss = GetComponent<NavMeshAgent>();

        isBossDead = false;

        isBossCameraActive = false;

    }

    void Update()
    {
        if (!instance.isAttackModeActivated)
        {
            if (Vector3.Distance(player.transform.position, transform.position) < 3f)
            {
                StartCoroutine("CanAttack");
                gameManager.GameOver(false);
            }
            else if (Vector3.Distance(player.transform.position, transform.position) < 20f)
            {
                CanFollow();

            }
            if (Vector3.Distance(player.transform.position, transform.position) > 20f)
            {
                ChangeToIdle();

            }
        }
        else
        {
            StartCoroutine("BossDead");
        }
    }

    private IEnumerator CanAttack()
    {


        bossAnimator.SetBool("isAttacking", true);
        bossAnimator.SetBool("isIdle", false);
        isBossCameraActive = true;
        //StartCoroutine("Wait");
        yield return new WaitForSeconds(2f);
       

    }
    private void CanFollow()
    {

        agentBoss.SetDestination(player.transform.position);
        bossIsComingSound.Stop();
        bossIsAttackingSound.Play();
        transform.LookAt(player.transform);
        state = BossStates.ATTACK;
        bossAnimator.SetBool("isRunning", true);
        state = BossStates.RUN;
    }

    private void ChangeToIdle()
    {

        bossAnimator.SetBool("isRunning", false);
        bossAnimator.SetBool("isAttacking", false);
        bossAnimator.SetBool("isIdle", true);

        state = BossStates.IDLE;

    }



  

    private IEnumerator BossDead()
    {
        Debug.Log("isDead");
        yield return new WaitForSeconds(0.5f);
        isBossDead = true;
        Destroy(boss);
    }


}

public enum BossStates { IDLE, RUN, ATTACK }
