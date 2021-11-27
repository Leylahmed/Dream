using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpenClose : MonoBehaviour
{
    [SerializeField] private GameObject lockedCanvas;

    [SerializeField] private GameObject infoCanvas;

    [SerializeField] private GameObject sceneLoaderCanvas;

    [SerializeField] private Transform player;

    [SerializeField] private KeyDataSO keyData;

    [SerializeField] private AudioSource knockingSound;

    [SerializeField] private AudioSource openCloseDoor;

    [SerializeField] private GameManager gameManager;

    [SerializeField] private GameObject doorCollider;

    [SerializeField] private AudioController audioController;

    public bool doorOpened;

    private bool coroutineAllowed;

    private Vector3 initialPosition;

    private bool isKeyActive;

    [SerializeField] private AudioSource bedroomSound;

    public bool GetDoorOpened()
    {
        return doorOpened;
    }
    public void SetDoorOpened(bool doorOpened)
    {
        this.doorOpened = doorOpened;
    }
    void Start()
    {
        doorOpened = false;

        coroutineAllowed = true;

        knockingSound.Play();

        initialPosition = transform.position;

        InvokeRepeating("ShowCanvas", 0f, 0.5f);
    }
    void Update()
    {
        if (!doorOpened)
        {
            if ((Input.GetKeyDown(KeyCode.F) && Vector3.Distance(initialPosition, player.transform.position) < 2.5f) && keyData.GetIsDoorActive())
            {
                StartCoroutine("OpenDoor");
                openCloseDoor.Play();
            }
           // audioController.PlayBedroomAudio();
        }
        else
        {
            audioController.PlayForestAudio();
            RenderSettings.fog = true;
            StartCoroutine("ChangeToForest");
        }
    }

    private IEnumerator OpenDoor()
    {
        coroutineAllowed = false;
        if (!doorOpened)
        {
            for (float i = 0f; i >= -90f; i -= 3f)
            {
                transform.localRotation = Quaternion.Euler(-90f, 0f, i);
                yield return new WaitForSeconds(0f);
            }
            doorOpened = true;

        }
        coroutineAllowed = true;
        doorCollider.SetActive(true);
        gameManager.isPlayerInForest = true;
    }
    private void ShowCanvas()
    {
        if (!keyData.GetIsDoorActive())
        {
            if (Vector3.Distance(initialPosition, player.transform.position) < 2.5f)
            {
                lockedCanvas.SetActive(true);
            }
            else
            {
                lockedCanvas.SetActive(false);
            }
        }
        else
        {
            if ( keyData.GetLife() == 3 && !keyData.GetIsKeyActive())
            {
                if (Vector3.Distance(initialPosition, player.transform.position) < 3f)
                {

                    infoCanvas.SetActive(true);
                }
                else
                {

                    infoCanvas.SetActive(false);
                }
            }
        }
    }

    private IEnumerator ChangeToForest()
    {
        knockingSound.Stop();
        bedroomSound.Stop();
        sceneLoaderCanvas.SetActive(true);
        for (float i = 45f; i >= 0f; i -= 3f)
        {
            transform.localRotation = Quaternion.Euler(-90f, 0f, i);
            yield return new WaitForSeconds(0f);
        }
        doorOpened = false;
        coroutineAllowed = true;
        yield return new WaitForSeconds(2f);
        sceneLoaderCanvas.SetActive(false);
        
    }


}
