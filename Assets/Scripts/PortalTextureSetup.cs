using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour {

	public Camera cameraA; // camera for portal A
	public Camera cameraB; // camera for portal B

	public Material cameraAMaterial; // material for portal A
	public Material cameraBMaterial; // material for portal B

	void Start () {
		// if either camera has a texture, remove it
		if (cameraA.targetTexture != null )
		{
			cameraA.targetTexture.Release();
		} else if (cameraB.targetTexture != null)
		{
			cameraB.targetTexture.Release();
		}

		// set new render textures for each camera and then loads the result into the materials.
		cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
		cameraAMaterial.mainTexture = cameraA.targetTexture;

		cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
		cameraBMaterial.mainTexture = cameraB.targetTexture;
	}
	
}