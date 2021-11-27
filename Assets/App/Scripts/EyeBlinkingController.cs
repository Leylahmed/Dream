using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBlinkingController : MonoBehaviour
{
    [SerializeField] private GameObject up;

    [SerializeField] private GameObject down;


   
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            Animation.Destroy(up);

            Animation.Destroy(down);
        }
    }

}
