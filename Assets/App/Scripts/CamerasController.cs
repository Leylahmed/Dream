using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasController : MonoBehaviour
{

    [SerializeField] private PlayerController playerController;

    [SerializeField] private BossController bossController;

    [SerializeField] private GameObject thirdPlayerCamera;

    [SerializeField] private GameObject firstCamera;

    private void Update()
    {

        if (!GameManager.gameManager.isPlayerInForest || (GameManager.gameManager.isBombCompleted && !GameManager.gameManager.isInside))
        {
            thirdPlayerCamera.SetActive(false);
            firstCamera.SetActive(true);
        }
        else if (GameManager.gameManager.isPlayerInForest && !GameManager.gameManager.isBombCompleted || GameManager.gameManager.isInside)
        {
            firstCamera.SetActive(false);
            thirdPlayerCamera.SetActive(true);
        }
    }
}
