using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this function gives the illusion of looking into the portal
public class PortalCamera : MonoBehaviour {
	public Transform cameraPlayer; // player's camera
	public Transform portal; // the portal where the player is located
	public Transform nextPortal; // the portal where the player is going to go
	
	void Update () {
		// moves the camera located at nextPortal relative to the player's position at the current portal
		Vector3 portalOffset = cameraPlayer.position - nextPortal.position;
		transform.position = portal.position + portalOffset;

		// angles and rotates the camera located at nextPortal relative to the player's position at the current portal
		float angularDiff = Quaternion.Angle(portal.rotation, nextPortal.rotation);
		Quaternion rotationalDiff = Quaternion.AngleAxis(angularDiff, Vector3.up);
		Vector3 updatedCamera = rotationalDiff * cameraPlayer.forward;
		transform.rotation = Quaternion.LookRotation(updatedCamera, Vector3.up);
	}
}