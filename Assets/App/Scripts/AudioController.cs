using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClipBedroom;
    [SerializeField] private AudioClip audioClipForest;
    [SerializeField] private AudioClip audioClipChristmas;
    [SerializeField] private AudioClip audioClipMushrooms;
    [SerializeField] private AudioClip audioClipChristmasRemix;
    [SerializeField] private AudioClip audioClipMushroomsRemix;

    void Start()
    {

    }

    public void PlayBedroomAudio()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(audioClipBedroom, 0.5f);
    }

    public void PlayForestAudio()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(audioClipForest, 0.5f);
    }

    public void PlayChristmasAudio()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(audioClipChristmas, 1f);
    }

    public void PlayChristmasDanceAudio()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(audioClipChristmas, 2f);
    }

    public void PlayChristmasRemixAudio()
    {
        audioSource.PlayOneShot(audioClipChristmasRemix, 2f);
    }

    public void PlayMushroomsAudio()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(audioClipMushrooms, 1f);
    }

    public void PlayMushroomsDanceAudio()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(audioClipMushrooms, 2f);
    }

    public void PlayMushroomsRemixAudio()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(audioClipMushroomsRemix, 2f);
    }
}
