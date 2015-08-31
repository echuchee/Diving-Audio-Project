using UnityEngine;
using System.Collections;

[ExecuteInEditMode]

public class Underwater : MonoBehaviour {

	public float m_UnderwaterCheckOffset = 0.001F;	
	public Color envFogColor;
	public Color underwaterFogColor = Color.blue;
	public Material sky1;
	public Material sky2;

	public float waterFogDensity = 0.03f; // fog density


	public bool IsUnderwater(Camera cam) {
		return cam.transform.position.y + m_UnderwaterCheckOffset < transform.position.y ? true : false;	
	}
			
	public void OnWillRenderObject()
	{
		Camera cam = Camera.current;

		if(IsUnderwater(cam)) 
		{
				
				GetComponent<Renderer>().sharedMaterial.shader.maximumLOD = 5;	
				RenderSettings.fog = true;
				RenderSettings.skybox = sky1;
				
			
		}
		else{

				GetComponent<Renderer>().sharedMaterial.shader.maximumLOD = 10;	
				RenderSettings.fog = false;
				RenderSettings.skybox = sky2;
			
		}
		
	}
}
