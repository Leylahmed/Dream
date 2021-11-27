using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomsPortalTeleporter : MonoBehaviour
{
	[SerializeField] private Transform player;
	[SerializeField] private Transform receiver;
	[SerializeField] private AudioController audioController;
	[SerializeField] private GameObject aquarium;
	[SerializeField] private GameObject madHatter;


	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.CompareTag("Player"))
		{
			player.position = receiver.position;
			player.rotation = receiver.rotation;

			madHatter.SetActive(false);
			aquarium.SetActive(false);

			RenderSettings.fog = true;

			audioController.PlayForestAudio();

			GameManager.gameManager.isInside = false;
		}

	}
}
