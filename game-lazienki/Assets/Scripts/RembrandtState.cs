using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RembrandtState : MonoBehaviour {
	public GameObject takePanel;

	void Update(){
		takePanelDisactivation ();
	}

	public void rembrandtTaken(){
		GameObject go = GameObject.Find("GameState");
		if(go == null){
			Debug.LogError("Failed to find 'GameState' object");
			this.enabled = false;
			return;
		}

		GameState gs = go.GetComponent<GameState>();

		gs.updateRembrandt ();
	}

	public void takePanelDisactivation(){
		GameObject go = GameObject.Find("GameState");
		if(go == null){
			Debug.LogError("Failed to find 'GameState' object");
			this.enabled = false;
			return;
		}

		GameState gs = go.GetComponent<GameState>();

		if (gs.returnRembrandt ())
			takePanel.SetActive (false);
	}
}
