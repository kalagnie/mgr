using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCharacter : MonoBehaviour {

	[SerializeField]
	private Sprite[] characterSprites;

	[SerializeField]
	private string[] characterText;

	[SerializeField]
	private string[] characterDescription;

	public void AddCharacterToInventory(int nr){
		GameObject go = GameObject.Find("GameState");
		if(go == null){
			Debug.LogError("Failed to find 'GameState' object");
			this.enabled = false;
			return;
		}

		GameState gs = go.GetComponent<GameState>();
		gs.addCharacter (characterSprites [nr], characterText[nr], characterDescription[nr]);
	}

}
