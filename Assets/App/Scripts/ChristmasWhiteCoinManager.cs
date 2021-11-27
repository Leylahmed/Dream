using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChristmasWhiteCoinManager : MonoBehaviour
{
    public static ChristmasWhiteCoinManager instance;

    [Header("Links")]
    [SerializeField] private GameObject whiteCoin;
    [SerializeField] private GameObject bombPart;
    [SerializeField] private AudioController audioController;
    [SerializeField] private Light lightInfo;


    private bool selectedWhiteCoin;
    public bool SelectedWhiteCoin { get => selectedWhiteCoin; set => selectedWhiteCoin = value; }


    void Awake()
    {
        instance = this;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioController.PlayChristmasDanceAudio();
            lightInfo.color = Color.green;
            whiteCoin.SetActive(false);
            ChristmasBlackCoinManager.instance.SelectedBlackCoin = false;
            selectedWhiteCoin = true;
            bombPart.SetActive(true);
        }
    }

}
