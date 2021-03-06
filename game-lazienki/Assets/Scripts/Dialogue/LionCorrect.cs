﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LionCorrect : MonoBehaviour {

	public void CorrectLion1(){
		GameObject go = GameObject.Find("GameState");
		if(go == null){
			Debug.LogError("Failed to find 'GameState' object");
			this.enabled = false;
			return;
		}

		GameState gs = go.GetComponent<GameState>();

		gs.updateLion1 ();
	}

	public void CorrectLion2(){
		GameObject go = GameObject.Find("GameState");
		if(go == null){
			Debug.LogError("Failed to find 'GameState' object");
			this.enabled = false;
			return;
		}

		GameState gs = go.GetComponent<GameState>();

		gs.updateLion2 ();
	}

	public void CorrectLion3(){
		GameObject go = GameObject.Find("GameState");
		if(go == null){
			Debug.LogError("Failed to find 'GameState' object");
			this.enabled = false;
			return;
		}

		GameState gs = go.GetComponent<GameState>();

		gs.updateLion3 ();
	}

	public void CorrectLion4(){
		GameObject go = GameObject.Find("GameState");
		if(go == null){
			Debug.LogError("Failed to find 'GameState' object");
			this.enabled = false;
			return;
		}

		GameState gs = go.GetComponent<GameState>();

		gs.updateLion4 ();
	}
}
