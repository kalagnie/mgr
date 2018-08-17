using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour {

	public GameObject go;

	private bool ItemTaken(string name){
		GameObject go = GameObject.Find("GameState");
		if(go == null){
			Debug.LogError("Failed to find 'GameState' object");
			this.enabled = false;
			return false;
		}

		GameState gs = go.GetComponent<GameState>();
		return gs.checkForItem (name);
	}

	public void DisableGameObject(string name){
		if (ItemTaken (name))
			go.gameObject.SetActive (false);
	}
		
}
