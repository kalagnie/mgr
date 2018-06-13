using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {

	//List of characters and list of items
	static public List<Item> playerInventory;
	static public List<Character> characterInventory;

	[SerializeField]
	private Sprite[] iconSprites;

	[SerializeField]
	private string[] itemText;

	[SerializeField]
	private Sprite[] characterSprites;

	[SerializeField]
	private string[] characterText;

	[SerializeField]
	private string[] characterDescription;

	public void AddItem(int nr){
		playerInventory = new List<Item> ();
		Item newItem = new Item ();

		newItem.iconSprite = iconSprites [nr];
		newItem.itemName = itemText[nr];

		playerInventory.Add (newItem);

	}

	public void AddCharacter(int nr){
		characterInventory = new List<Character> ();
		Character newCharacter = new Character ();

		newCharacter.characterSprite = characterSprites [nr];
		newCharacter.characterName = characterText[nr];
		newCharacter.characterInfo = characterDescription[nr];

		characterInventory.Add (newCharacter);
	}
		
	//static GameState TheRightGameStatus;

	//void Start(){
	//	if (TheRightGameStatus != null) {
	//		//I am not the one => destroy
	//		Destroy(this.gameObject);
	//		return;
	//	}

		//I am the one
	//	TheRightGameStatus = this;
	//	GameObject.DontDestroyOnLoad (this.gameObject);
	//}

}
