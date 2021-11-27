using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private KeyDataSO keyData;

    [SerializeField] private Animator playerAnimator;

    [SerializeField] private Transform bossTransform;

    [SerializeField] private AudioSource explosionSound;

    [SerializeField] private ParticleSystem explosionEffect;

    [SerializeField] private GameManager gameManager;

    [SerializeField] private GameObject infoCanvas;

    //[SerializeField] private Transform player;

    [SerializeField] private Transform receiver;

   

    public bool isFirstPlayerCameraActive;

    public bool isThirdPlayerCameraActive;

    public bool isAttackModeActivated;
    

    void Start()
    {
        isAttackModeActivated = false;

        explosionEffect.Stop();

        isFirstPlayerCameraActive = false;

        isThirdPlayerCameraActive = true;


    }

    private void Update()
    {

        if (!isAttackModeActivated)
        {
            StartCoroutine("CanAttackOrMove");
        }

    }
    private IEnumerator CanAttackOrMove()
    {
        if (Vector3.Distance(transform.position, bossTransform.position) < 15f)
        {
            if (Input.GetKeyDown(KeyCode.F) && keyData.GetBombParts() == 2)
            {
                playerAnimator.SetTrigger("CanAttack");
                explosionSound.Play();
                explosionEffect.Play();
                isAttackModeActivated = true;
                keyData.SetBombParts(0);
                yield return new WaitForSeconds(1f);
                playerAnimator.SetTrigger("CanMove");

                gameManager.GameOver(true);
                yield return new WaitForSeconds(3f);

            }
        }


    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("doorCollider"))
        {

            transform.position = receiver.position;

            transform.rotation = receiver.rotation;


        }

    }

}


