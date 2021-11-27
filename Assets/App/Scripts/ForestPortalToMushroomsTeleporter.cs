using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestPortalToMushroomsTeleporter : MonoBehaviour
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
			aquarium.SetActive(true);
			madHatter.SetActive(true);

			RenderSettings.fog = false;

			player.position = receiver.position;
			player.rotation = receiver.rotation;

			audioController.PlayMushroomsAudio();

			GameManager.gameManager.isInside = true;
		}

	}
}
