using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour {

	public Transform player; // the player object
	public Transform destination; // where the player is being sent to 

	private bool enteredPortal = false;

	// if the player enters the poral, update "enteredPortal" to true
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player")
		{
			enteredPortal = true;
		}
	}

	// if the player exits the poral, update "enteredPortal" to false
	void OnTriggerExit (Collider other)
	{
		if (other.tag == "Player")
		{
			enteredPortal = false;
		}
	}

	// portal teleportation
	void Update () {
		if (enteredPortal)
		{
			Vector3 portalPosition = player.position - transform.position;
			float entranceDotProduct = Vector3.Dot(transform.up, portalPosition); // checks the dot product of the player vector relative to the portal vector

			// when the player if facing the portal, there is a portal vector pointing upwards, and a player vector pointing towards the player

			// when the dot product between these two vectors is negative, it means the player has crossed the portal
			if (0f > entranceDotProduct)
			{
				// rotates and teleports the player to the other portal
				float rotationalDiff = -Quaternion.Angle(transform.rotation, destination.rotation) + 180;
				player.Rotate(Vector3.up, rotationalDiff);

				Vector3 positionOffset = Quaternion.Euler(0f, rotationalDiff, 0f) * portalPosition;
				player.position = destination.position + positionOffset;

				enteredPortal = false; // player has been successfully teleported and left the portal 
			}
		}
	}
}