using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] private GameObject bomb;
    [SerializeField] private KeyDataSO keyData;

    private int bombPartCount;


    void Start()
    {
        bombPartCount = keyData.GetBombParts();
    }
     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bombPartCount++;

            keyData.SetBombParts(bombPartCount);

            bomb.SetActive(false);

        }
    }
}
