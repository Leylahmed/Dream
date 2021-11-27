using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager gameManager;

    [SerializeField] private KeyDataSO keyData;

    [SerializeField] private AudioController audioController;

    [SerializeField] private Text bombText;

    [SerializeField] private GameObject myselfObject;

    [SerializeField] private GameObject bossObject;

    [SerializeField] private ParticleSystem explosionEffect;

    [SerializeField] private GameObject roomLocation;

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject sunLight;

    [SerializeField] private GameObject doorCollider;

    [SerializeField] private GameObject restartCanvas;

    [SerializeField] private GameObject startCanvas;

    public bool isSunLightOn;

    public bool isPlayerInForest;

    public bool isInside;

    public bool isBombCompleted;

    private Vector3 initialPosition;

    private void Awake()
    {
        gameManager = this;
    }
    void Start()
    {
        isPlayerInForest = false;

        isInside = false;

        startCanvas.SetActive(true);

        audioController.PlayBedroomAudio();

    }

    void Update()
    {
        if (isPlayerInForest)
        {
            sunLight.SetActive(true);
        }
        else
        {
            sunLight.SetActive(false);

        }
        if (keyData.GetBombParts() == 1)
        {
            bombText.text = "Magic weapon: 1/2";

        }

        if (keyData.GetBombParts() == 2)
        {
            bombText.text = "Magic weapon: 2/2";

            isBombCompleted = true;

            CallBoss();

        }
    }

    public void GameOver(bool isWin)
    {
        if (!isWin)
        {
            audioController.PlayBedroomAudio();
            doorCollider.SetActive(false);
            isPlayerInForest = false;
            player.transform.position = roomLocation.transform.position;

            if (keyData.GetLife() != 0)
            {
                keyData.SetLife(keyData.GetLife() - 1);   
            }
            else
            {
                UnityEngine.Cursor.lockState = CursorLockMode.None;
                restartCanvas.SetActive(true);
            }

        }
        else
        {
            myselfObject.SetActive(true);
        }
    }

    public void onClickStartButton()
    {
        startCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void OnClickRestartButton()
    {
            keyData.SetLife(3);
            keyData.SetIsDoorActive(false);
            keyData.SetIsKeyActive(true);
            keyData.SetBombParts(0);
            SceneManager.LoadScene("Forest");

    }

    private void CallBoss()
    {
        bossObject.SetActive(true);
        explosionEffect.Stop();

    }
}
