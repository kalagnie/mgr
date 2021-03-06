﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SobieskiQuestion : MonoBehaviour {

	//listy z pytaniami i odpowiedzimi
	public string[] questions;
	public string[] answers1;
	public string[] answers2;

	//Tekst pytan i odpowiedzi
	[SerializeField]
	private Text questionText;
	public Button answer1Button;
	public Button answer2Button;

	public GameObject takeItemPanel;
	public GameObject takeItemPanel2;

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

		if (gs.returnSobieski() == 1) {
			currentText = 6;
			if (gs.returnChopin () == 2)
				answer2Button.gameObject.SetActive (true);
			else
				answer2Button.gameObject.SetActive (false);
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
	}

	public void answer1Selected(){
		if (currentText == 0 || currentText == 6)
			SceneManager.LoadScene (1);
		else if (currentText == 2)
			currentText = currentText + 2;
		else if (currentText == 3)
			currentText = currentText - 1;
		else if (currentText == 4) {
			currentText = currentText + 1;
			answer2Button.gameObject.SetActive (false);
		}
		else if (currentText == 5) {
			takeItemPanel.gameObject.SetActive (true);
			GameObject go = GameObject.Find("GameState");
			if(go == null){
				Debug.LogError("Failed to find 'GameState' object");
				this.enabled = false;
				return;
			}

			GameState gs = go.GetComponent<GameState>();
			gs.updateSobieski (1);
			gs.updateLetter ();
			answer2Button.gameObject.SetActive (false);
		}
		else if(currentText == 7) {
			takeItemPanel2.gameObject.SetActive (true);
			GameObject go = GameObject.Find("GameState");
			if(go == null){
				Debug.LogError("Failed to find 'GameState' object");
				this.enabled = false;
				return;
			}

			GameState gs = go.GetComponent<GameState>();
			gs.updateSobieski (2);
			gs.updateApple ();
		}

		else if (currentText < 7)
				currentText = currentText + 1;			
	}

	public void answer2Selected(){
		if (currentText == 3 || currentText == 4)
			SceneManager.LoadScene (1);
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
