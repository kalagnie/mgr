using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SobieskiQuestion : MonoBehaviour {

	public string[] questions;
	public string[] answers1;
	public string[] answers2;

	//Tekst pytan i odpowiedzi
	[SerializeField]
	private Text questionText;
	public Button answer1Button;
	public Button answer2Button;

	private int currentText = 0;

	// Use this for initialization
	void Start () {
		if (GameState.visitedSobieski == 1) {
			answer2Button.gameObject.SetActive (true);
			currentText = 6;
		}

		updateText ();
	}
	
	// Update is called once per frame
	void Update () {
		updateText ();
	}

	void updateText(){
		questionText.text = questions [currentText];
		answer1Button.GetComponentInChildren<Text>().text= answers1 [currentText];
		answer2Button.GetComponentInChildren<Text>().text = answers2 [currentText];

		if(currentText == 6)
			answer2Button.gameObject.SetActive (true);
	}

	public void answer1Selected(){
		if (currentText == 0 || currentText == 6 || currentText == 7)
			Debug.Log ("EXIT");
			//SceneManager.LoadScene (1);
		else if (currentText == 2)
			currentText = currentText + 2;
		//else if(currentText == 7)
		//okienko
		else if (currentText == 3)
			currentText = currentText - 1;
		else if (currentText == 4) {
			currentText = currentText + 1;
			answer2Button.gameObject.SetActive (false);
		}
		else if (currentText < 7)
				currentText = currentText + 1;			
	}

	public void answer2Selected(){
		if (currentText == 3 || currentText == 4)
			Debug.Log ("EXIT");
			//SceneManager.LoadScene (1);
		else if (currentText == 1)
			currentText = 3;
		else if (currentText == 2) {
			currentText = 5;
			answer2Button.gameObject.SetActive (false);
		}
		else if (currentText == 6) {
			answer2Button.gameObject.SetActive (false);
			currentText = currentText + 1;
		}
		else if (currentText < 7)
				currentText = currentText + 1;
	}
}
