using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerController : MonoBehaviour
{
    [SerializeField] private KeyDataSO keyData;

    [SerializeField] private GameObject key;

    [SerializeField] private GameObject infoCanvas;

    [SerializeField] private AudioSource drawerOpenSound;

    [SerializeField] private AudioSource drawerCloseSound;

    [SerializeField] private GameObject upperDrawer;

    //upper drawer's initial position
    private Vector3 initialPosition;

    private bool coroutineAllowed;

    private bool drawerOpened;

    private bool isDoorActive;

    private bool isKeyActive;

    private int life;

    private bool isTriggerEnter;

    void Start()
    {
        isTriggerEnter = false;

        drawerOpened = false;

        coroutineAllowed = true;
        //upper box's initial position
        initialPosition = upperDrawer.transform.position;

        life = keyData.GetLife();

        isKeyActive = keyData.GetIsKeyActive();

        if (life == 3)
        {
            key.SetActive(true);
            keyData.SetIsKeyActive(true);
            isKeyActive = keyData.GetIsKeyActive();
            keyData.SetIsDoorActive(false);
            isDoorActive = keyData.GetIsDoorActive();
            InvokeRepeating("ShowCanvas",0,0.5f);
        }
        else
        {
            key.SetActive(false);
            keyData.SetIsKeyActive(false);
            isKeyActive = keyData.GetIsKeyActive();
            keyData.SetIsDoorActive(true);
            isDoorActive = keyData.GetIsDoorActive();
        }
    }
    private void Update()
    {
        if (isTriggerEnter && Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine("OpenCloseDrawer");
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggerEnter = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggerEnter = false;
        }
    }
    private IEnumerator OpenCloseDrawer()
    {
        coroutineAllowed = false;
        //upper box opening
        if (!drawerOpened)
        {
            drawerOpenSound.Play();

            for (float i = 0f; i < 1f; i += 0.1f)
            {
                upperDrawer.transform.localPosition = new Vector3(upperDrawer.transform.localPosition.x, upperDrawer.transform.localPosition.y, upperDrawer.transform.localPosition.z + 0.05f);
                yield return new WaitForSeconds(0f);
            }

            drawerOpened = true;

        }
        //upper box closing if key is not active
        else if (drawerOpened && !isKeyActive)//drawer opened and key isn't in drawer
        {
            drawerCloseSound.Play();

            for (float i = 1f; i > 0f; i -= 0.1f)
            {
                upperDrawer.transform.localPosition = new Vector3(upperDrawer.transform.localPosition.x, upperDrawer.transform.localPosition.y, upperDrawer.transform.localPosition.z - 0.05f);
                yield return new WaitForSeconds(0f);
            }
            upperDrawer.transform.position = initialPosition;
            drawerOpened = false;
        }
        //key is taking
        else if (drawerOpened && isKeyActive)//drawer opened and key is in drawer
        {
            drawerCloseSound.Stop();
            TakeKey();
        }
        coroutineAllowed = true;
    }
    private void ShowCanvas()
    {
        if (life == 3 && isTriggerEnter)
        {
            infoCanvas.SetActive(true);
        }
        else
        {
            infoCanvas.SetActive(false);
        }
    }

    private void TakeKey()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            key.SetActive(false);
            keyData.SetIsKeyActive(false);
            isKeyActive = keyData.GetIsKeyActive();
            keyData.SetIsDoorActive(true);
            isDoorActive = keyData.GetIsDoorActive();
        }

    }

    //void Update()
    //{

    //    if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(initialPosition, player.transform.position) < 2f)
    //    {
    //        StartCoroutine("OpenDrawer");
    //        if (drawerOpened && isKeyInScene)
    //        {
    //            drawerCloseSound.Stop();
    //            TakeKey();
    //        }
    //        else if (!drawerOpened)
    //        {
    //            drawerOpenSound.Play();
    //        }
    //        else
    //        {
    //            drawerCloseSound.Play();
    //        }
    //    }
    //    if ((life == 0 || life == 3) && isKeyInScene)
    //    {
    //        keyData.SetIsKeyActive(true);
    //        isKeyActive = keyData.GetIsKeyActive();
    //        key.SetActive(true);
    //        keyData.SetIsDoorActive(false);
    //        isDoorActive = keyData.GetIsDoorActive();
    //    }
    //    else if ((life == 0 || life == 3) && !isKeyInScene)
    //    {
    //        key.SetActive(false);
    //        keyData.SetIsDoorActive(true);
    //        isDoorActive = keyData.GetIsDoorActive();
    //    }
    //    if (life > 0 && life < 3)
    //    {
    //        isKeyActive = false;
    //        keyData.SetIsKeyActive(isKeyActive);
    //        key.SetActive(false);
    //        keyData.SetIsDoorActive(true);
    //        isDoorActive = keyData.GetIsDoorActive();
    //        infoCanvas.SetActive(false);
    //    }

    //}
}
