using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrownState : MonoBehaviour {

	public void crownTaken(){
		GameObject go = GameObject.Find("GameState");
		if(go == null){
			Debug.LogError("Failed to find 'GameState' object");
			this.enabled = false;
			return;
		}

		GameState gs = go.GetComponent<GameState>();

		gs.updateCrown ();
	}
}
