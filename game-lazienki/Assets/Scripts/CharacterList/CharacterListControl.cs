using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterListControl : MonoBehaviour {

	public List<Character> characterInventory;

	[SerializeField]
	private GameObject characterTemplate;

	[SerializeField]
	private Sprite[] characterSprites;

	[SerializeField]
	private string[] characterText;

	[SerializeField]
	private string[] characterDescription;

	void Start(){

		characterInventory = new List<Character> ();

		for (int i = 0; i < 2; i++) {

			Character newCharacter = new Character ();
		
			newCharacter.characterSprite = characterSprites [1];
			newCharacter.characterName = characterText[1];
			newCharacter.characterInfo = characterDescription[1];

			characterInventory.Add (newCharacter);
		}
		GenerateCharacterInventory ();
	}

	void GenerateCharacterInventory(){
		int i = 1;
		foreach (Character newCharacter in characterInventory){
			GameObject item = Instantiate (characterTemplate) as GameObject;
			item.SetActive (true);

			//Generating Character Inventory List
			item.GetComponent <CharacterList>().SetText (newCharacter.characterName);
			item.GetComponent <CharacterList> ().SetIcon (newCharacter.characterSprite);
			item.GetComponent <CharacterList> ().SetDescription (newCharacter.characterInfo);

			item.transform.SetParent (characterTemplate.transform.parent, false); //parent the same as for  itemTemplate
			i++;
		}
	}
}
