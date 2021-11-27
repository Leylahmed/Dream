using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChristmasPortalTeleporter : MonoBehaviour
{
	[SerializeField] private Transform player;
	[SerializeField] private Transform receiver;
	[SerializeField] private AudioController audioController;

	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.CompareTag("Player"))
		{
			player.position = receiver.position;
			player.rotation = receiver.rotation;

			audioController.PlayForestAudio();

			GameManager.gameManager.isInside = false;
		}

	}
}
