using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChristmasBlackCoinManager : MonoBehaviour
{
    public static ChristmasBlackCoinManager instance;

    [Header("Links")]
    [SerializeField] private GameObject blackCoin;
    [SerializeField] private Light lightInfo;
    [SerializeField] private AudioController audioController;

    private bool selectedBlackCoin;
    public bool SelectedBlackCoin { get => selectedBlackCoin; set => selectedBlackCoin = value; }


    void Awake()
    {
        instance = this;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioController.PlayChristmasRemixAudio();
            lightInfo.color = Color.red;
            blackCoin.SetActive(false);
            ChristmasWhiteCoinManager.instance.SelectedWhiteCoin = false;
            selectedBlackCoin = true;

        }

    }

}
