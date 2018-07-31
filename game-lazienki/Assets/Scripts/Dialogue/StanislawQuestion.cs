using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StanislawQuestion : MonoBehaviour {
	//listy z pytaniami i odpowiedzimi
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
		/*
		GameObject go = GameObject.Find("GameState");
		if(go == null){
			Debug.LogError("Failed to find 'GameState' object");
			this.enabled = false;
			return;
		}

		GameState gs = go.GetComponent<GameState>();

		if (gs.returnSobieski() == 1) {
			answer2Button.gameObject.SetActive (true);
			currentText = 5;
		}
		*/
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

		//test
		if(currentText == 5)
			answer2Button.gameObject.SetActive (true);
	}

	public void answer1Selected(){
		if (currentText == 0) {
			Debug.Log ("0 pressed");
			currentText = currentText + 2;
		}
		else if (currentText == 1)
			currentText = currentText + 1;
		else if (currentText == 2) {
			answer2Button.gameObject.SetActive (false);
			currentText = currentText + 2;
		} else if (currentText == 3) {
			answer2Button.gameObject.SetActive (false);
			currentText = currentText + 1;
		} else if (currentText == 4) {
			currentText = currentText + 1;
			/*
			GameObject go = GameObject.Find("GameState");
			if(go == null){
				Debug.LogError("Failed to find 'GameState' object");
				this.enabled = false;
				return;
			}

			GameState gs = go.GetComponent<GameState>();
			gs.updateSobieski (1);

			//SceneManager.LoadScene (1);
			*/
			Debug.Log ("EXIT");
		}
	}

	public void answer2Selected(){
		if (currentText < 3)
			currentText = currentText + 1;
		else if (currentText == 3) {
			currentText = currentText + 1;
			answer2Button.gameObject.SetActive (false);
		}		
	}
}