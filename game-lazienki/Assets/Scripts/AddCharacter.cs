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
		GameState.characterInventory = new List<Character> ();
		Character newCharacter = new Character ();

		newCharacter.characterSprite = characterSprites [nr];
		newCharacter.characterName = characterText[nr];
		newCharacter.characterInfo = characterDescription[nr];

		GameState.characterInventory.Add (newCharacter);
	}

}
