using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LionsQuestion : MonoBehaviour {

	//listy z pytaniami i odpowiedzimi
	public string[] questions;
	public string[] answers1;
	public string[] answers2;

	//Tekst pytan i odpowiedzi
	[SerializeField]
	private Text questionText;
	public Button answer1Button;
	public Button answer2Button;

	public GameObject Panel;
	public GameObject puzzlePanel;
	public Button next;

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

		if (gs.returnLwy() == 1) {
			currentText = 3;
			Panel.gameObject.SetActive (false);
			puzzlePanel.gameObject.SetActive (true);
		}

		updateText ();
	}

	// Update is called once per frame
	void Update () {
		updateText ();
		enableNextButton ();
	}

	void updateText(){
		questionText.text = questions [currentText];
		answer1Button.GetComponentInChildren<Text>().text= answers1 [currentText];
		if (currentText < 2)
			answer2Button.GetComponentInChildren<Text>().text = answers2 [currentText];
	}

	public void answer1Selected(){
		if (currentText == 0) {
			//Debug.Log ("EXIT");
			SceneManager.LoadScene (1);
		} else if (currentText == 1) {
			currentText = 3;
			Panel.gameObject.SetActive (false);
			puzzlePanel.gameObject.SetActive (true);

			answer2Button.gameObject.SetActive (false);
		} else if (currentText == 2) {
			Panel.gameObject.SetActive (false);
			puzzlePanel.gameObject.SetActive (true);

			currentText = 3;
			answer2Button.gameObject.SetActive (false);

			GameObject go = GameObject.Find("GameState");
			if(go == null){
				Debug.LogError("Failed to find 'GameState' object");
				this.enabled = false;
				return;
			}

			GameState gs = go.GetComponent<GameState>();
			gs.updateLwy(1);

		} else if ((currentText == 3) || (currentText == 4)) {
			currentText = currentText +1;	
		}
		else if (currentText == 5) {
			
			GameObject go = GameObject.Find("GameState");
			if(go == null){
				Debug.LogError("Failed to find 'GameState' object");
				this.enabled = false;
				return;
			}

			GameState gs = go.GetComponent<GameState>();
			gs.updateLwy(2);
			SceneManager.LoadScene (1);
		}
	}

	public void answer2Selected(){
		if (currentText == 0) {
			currentText = 1;
		}			
		else if (currentText == 1) {
			currentText = 2;
			answer2Button.gameObject.SetActive (false);
		}
	}

	private void enableNextButton(){

		GameObject go = GameObject.Find("GameState");
		if(go == null){
			Debug.LogError("Failed to find 'GameState' object");
			this.enabled = false;
			return;
		}

		GameState gs = go.GetComponent<GameState>();

		if((gs.returnCheckedLions () [0] == 1) && (gs.returnCheckedLions () [1] == 1) && (gs.returnCheckedLions () [2] == 1) && (gs.returnCheckedLions () [3] == 1))
			next.gameObject.SetActive (true);
	}

	public void nextButton(){
		Panel.gameObject.SetActive (true);
		puzzlePanel.gameObject.SetActive (false);
		answer2Button.gameObject.SetActive (false);
	}

}
