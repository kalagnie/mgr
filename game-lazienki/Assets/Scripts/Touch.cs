using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Touch : MonoBehaviour {

	[SerializeField]
	Text text;

	Ray ray;

	// Update is called once per frame
	void Update () {

		ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
		RaycastHit hit;
		//if collide with sth => true, ray from the camera to infinity?
		if (Physics.Raycast (ray, out hit)) { //Mathf.Infinity
			
			if (hit.transform.name == "PalacNaWodzie") {
				text.text = hit.transform.name + " hit";
			}
			else if (hit.transform.name == "BialyDomek") {
				text.text = hit.transform.name + " hit";
			}
		}
	}
}
