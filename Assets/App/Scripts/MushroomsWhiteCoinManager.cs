using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomsWhiteCoinManager : MonoBehaviour
{
    public static MushroomsWhiteCoinManager instance;

    [Header("Links")]
    [SerializeField] private GameObject whiteCoin;
    [SerializeField] private GameObject bombPart;
    [SerializeField] private AudioController audioController;


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
            audioController.PlayMushroomsDanceAudio();
            whiteCoin.SetActive(false);
            MushroomsBlackCoinManager.instance.SelectedBlackCoin = false;
            SelectedWhiteCoin = true;
            bombPart.SetActive(true);

        }
    }

}
