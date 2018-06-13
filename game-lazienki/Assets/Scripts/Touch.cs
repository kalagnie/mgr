using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Touch : MonoBehaviour {

	//[SerializeField]
	//Text nameText;

	//public Image namePanel;

	Ray ray;

	// Update is called once per frame
	void Update () {
		ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
		RaycastHit hit;
		//if collide with sth => true, ray from the camera to infinity?
		if (Physics.Raycast (ray, out hit)) {

			if (hit.transform.name == "PalacNaWodzie" || hit.transform.name == "BialyDomek") {
				SceneManager.LoadScene (4); //4 => architecture
				/*nameText.text = "Palac na Wodzie";
				namePanel.transform.position = Input.GetTouch (0).position;
				namePanel.gameObject.SetActive (true);
				nameText.gameObject.SetActive (true);
				*/
			} else if (hit.transform.name == "Sobieski") {
				SceneManager.LoadScene (3); //3=> conversation
			}
			else if (hit.transform.name == "Palac") {
				SceneManager.LoadScene (2); //3=> conversation
			}
		}
	}
}
