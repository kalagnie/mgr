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

		if ((nr == 0 && gs.returnChopin() == 0) || (nr == 1 && gs.returnSienkiewicz() == 0) || (nr == 2 && gs.returnSobieski() == 0) || (nr == 3 && gs.returnStanislaw() == 0))
			gs.addCharacter (characterSprites [nr], characterText[nr], characterDescription[nr]);
	}

}
