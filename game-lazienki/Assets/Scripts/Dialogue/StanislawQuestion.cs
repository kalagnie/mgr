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

	public GameObject takePanel;
	public GameObject givePanel;

	private int currentText = 0;

	// Use this for initialization
	void Start () {


		GameObject go = GameObject.Find("GameState");
		if(go == null){
			Debug.LogError("Failed to find 'GameState' object");
			this.enabled = false;
			return;
		}

		GameState gs = go.GetComponent<GameState>();

		if (gs.returnStanislaw() == 1) {
			if (gs.checkForItem("Rembrandt"))
				answer2Button.gameObject.SetActive (true);
			else
				answer2Button.gameObject.SetActive (false);
			currentText = 5;
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
		if (currentText <= 4)
			answer2Button.GetComponentInChildren<Text>().text = answers2 [currentText];
		else if (currentText == 5)
			answer2Button.GetComponentInChildren<Text>().text = answers2 [4];
	}

	public void answer1Selected(){
		if (currentText == 0)
			currentText = currentText + 2;
		else if (currentText == 1)
			currentText = currentText + 1;
		else if (currentText == 2) {
			answer2Button.gameObject.SetActive (false);
			currentText = currentText + 2;
		} else if (currentText == 3) {
			answer2Button.gameObject.SetActive (false);
			currentText = currentText + 1;
		} else if (currentText == 4) {
			
			GameObject go = GameObject.Find ("GameState");
			if (go == null) {
				Debug.LogError ("Failed to find 'GameState' object");
				this.enabled = false;
				return;
			}

			GameState gs = go.GetComponent<GameState> ();
			gs.updateStanislaw (1);

			SceneManager.LoadScene (1);

			Debug.Log ("EXIT");
		} else if (currentText == 5) {
			SceneManager.LoadScene (1);
		} else if (currentText == 6) {
			GameObject go = GameObject.Find ("GameState");
			if (go == null) {
				Debug.LogError ("Failed to find 'GameState' object");
				this.enabled = false;
				return;
			}

			GameState gs = go.GetComponent<GameState> ();
			gs.updateStanislaw (2);
			gs.updateSceptre ();

			takePanel.gameObject.SetActive (true);
		}
	}

	public void answer2Selected(){
		if (currentText < 3)
			currentText = currentText + 1;
		else if (currentText == 3) {
			currentText = currentText + 1;
			answer2Button.gameObject.SetActive (false);
		}	
		else if (currentText == 5){
			currentText = currentText + 1;
			givePanel.gameObject.SetActive (true);
			answer2Button.gameObject.SetActive (false);
		}
	}
}