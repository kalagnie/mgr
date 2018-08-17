using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChopinQuestion : MonoBehaviour {

	//listy z pytaniami i odpowiedzimi
	public string[] questions;
	public string[] answers1;
	public string[] answers2;

	//Tekst pytan i odpowiedzi
	[SerializeField]
	private Text questionText;
	public Button answer1Button;
	public Button answer2Button;

	public GameObject givePanel;

	private int currentText = 0;
	private int currentAnswer2Text = 0;

	// Use this for initialization
	void Start () {


		GameObject go = GameObject.Find ("GameState");
		if (go == null) {
			Debug.LogError ("Failed to find 'GameState' object");
			this.enabled = false;
			return;
		}

		GameState gs = go.GetComponent<GameState> ();

		if (gs.returnChopin () == 1) {
			answer2Button.gameObject.SetActive (false);
			currentText = 3;
		}
		if (gs.returnMusic ()) {
			currentText = 4;
			currentAnswer2Text = 1;
			if(gs.returnLetter())
				answer2Button.gameObject.SetActive (true);
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
		answer2Button.GetComponentInChildren<Text>().text = answers2 [currentAnswer2Text];
	}

	public void answer1Selected(){
		if (currentText == 0) {
			currentText = currentText + 1;
			currentAnswer2Text = currentAnswer2Text + 1;
			answer2Button.gameObject.SetActive (false);
		} else if (currentText == 1) {
			currentText = currentText + 1;
		}
		else if (currentText == 2) {
			
			GameObject go = GameObject.Find ("GameState");
			if (go == null) {
				Debug.LogError ("Failed to find 'GameState' object");
				this.enabled = false;
				return;
			}

			GameState gs = go.GetComponent<GameState> ();
			gs.updateChopin (1);

			SceneManager.LoadScene (1);
			//Debug.Log ("EXIT");
		}
		else if (currentText == 3)
			SceneManager.LoadScene (1);
			//.Log ("EXIT");
		else if (currentText == 4) {
			SceneManager.LoadScene (1);
			//Debug.Log ("EXIT");
		} else if (currentText == 5) {
			currentText = currentText + 1;
			answer2Button.gameObject.SetActive (true);
		} else if (currentText == 6) {
			currentText = currentText + 1;
			currentAnswer2Text = 3;
		} else if (currentText == 7) {GameObject go = GameObject.Find ("GameState");
			if (go == null) {
				Debug.LogError ("Failed to find 'GameState' object");
				this.enabled = false;
				return;
			}

			GameState gs = go.GetComponent<GameState> ();
			gs.updateChopin (2);
			answer2Button.gameObject.SetActive (false);
			givePanel.gameObject.SetActive (true);
			currentText = currentText + 1;
		} else if (currentText == 8) {
			SceneManager.LoadScene (1);
			//Debug.Log ("EXIT");currentText = currentText - 1;
		}
	}

	public void answer2Selected(){
		if (currentText == 0){
			SceneManager.LoadScene (1);
			//Debug.Log ("EXIT");
		}
		else if (currentText == 4) {
			currentText = 5;
			answer2Button.gameObject.SetActive (false);
			currentAnswer2Text = 2;
		}	
		else if (currentText == 6){
			currentText = 8;
			givePanel.gameObject.SetActive (true);
			GameObject go = GameObject.Find ("GameState");
			if (go == null) {
				Debug.LogError ("Failed to find 'GameState' object");
				this.enabled = false;
				return;
			}

			GameState gs = go.GetComponent<GameState> ();
			gs.updateChopin (2);
			answer2Button.gameObject.SetActive (false);
		}
		else if (currentText == 7){
			currentText = 8;
			answer2Button.gameObject.SetActive (false);
		}
	}
}
