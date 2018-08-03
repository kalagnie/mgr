using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LionCorrect : MonoBehaviour {

	public Text test; 

	public void CorrectLion1(){
		GameObject go = GameObject.Find("GameState");
		if(go == null){
			Debug.LogError("Failed to find 'GameState' object");
			this.enabled = false;
			return;
		}

		GameState gs = go.GetComponent<GameState>();

		gs.updateLwy (0);
	}

	public void CorrectLion2(){
		GameObject go = GameObject.Find("GameState");
		if(go == null){
			Debug.LogError("Failed to find 'GameState' object");
			this.enabled = false;
			return;
		}

		GameState gs = go.GetComponent<GameState>();

		gs.updateLwy (1);
	}

	public void CorrectLion3(){
		GameObject go = GameObject.Find("GameState");
		if(go == null){
			Debug.LogError("Failed to find 'GameState' object");
			this.enabled = false;
			return;
		}

		GameState gs = go.GetComponent<GameState>();

		gs.updateLwy (2);
	}

	public void CorrectLion4(){
		GameObject go = GameObject.Find("GameState");
		if(go == null){
			Debug.LogError("Failed to find 'GameState' object");
			this.enabled = false;
			return;
		}

		GameState gs = go.GetComponent<GameState>();

		gs.updateLwy (3);
	}

	//test
	public void returnLwy(){
		GameObject go = GameObject.Find("GameState");
		if(go == null){
			Debug.LogError("Failed to find 'GameState' object");
			this.enabled = false;
			return;
		}

		GameState gs = go.GetComponent<GameState>();

		test.text = gs.intLions (0).ToString() + "\n" + gs.intLions (1).ToString() + "\n" + gs.intLions (2).ToString() + "\n" + gs.intLions (3).ToString() + "\n";

	}
}
