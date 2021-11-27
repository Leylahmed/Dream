using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomsBlackCoinManager : MonoBehaviour
{
    public static MushroomsBlackCoinManager instance;

    [Header("Links")]
    [SerializeField] private GameObject blackCoin;
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
            audioController.PlayMushroomsRemixAudio();
            blackCoin.SetActive(false);
            MushroomsWhiteCoinManager.instance.SelectedWhiteCoin = false;
            selectedBlackCoin = true;

        }

    }

}
