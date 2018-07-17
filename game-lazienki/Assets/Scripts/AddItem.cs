using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : MonoBehaviour {
	[SerializeField]
	private Sprite[] iconSprites;

	[SerializeField]
	private string[] itemText;

	public void AddItemToInventory(int nr){
		GameObject go = GameObject.Find("GameState");
		if(go == null){
			Debug.LogError("Failed to find 'GameState' object");
			this.enabled = false;
			return;
		}

		GameState gs = go.GetComponent<GameState>();
		gs.addItem (iconSprites [nr], itemText[nr]);
	}
}