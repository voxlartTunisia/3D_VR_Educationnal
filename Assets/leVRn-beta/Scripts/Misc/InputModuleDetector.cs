using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using OVRInputModule = ControllerSelection.OVRInputModule;

public class InputModuleDetector : MonoBehaviour
{
	public List<GameObject> canvases;
	public OVRInputModule ovrInput;
	public StandaloneInputModule standaloneInput;
	// Use this for initialization
	#if UNITY_EDITOR
	void Awake(){
		ovrInput.enabled = false;
		standaloneInput.enabled = true;
		foreach (GameObject canvas in canvases){
			canvas.GetComponent<GraphicRaycaster>().enabled = true;
		}
		
		
	}
	#endif
}
