using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//test
//using UnityEngine.UI;

public class GameState : MonoBehaviour {

	//public Text test;

	static public GameState Instance; //The right GameStatus { set; get; }

	//List of characters and list of items
	static public List<Item> playerInventory;
	static public List<Character> characterInventory;

	void Start(){
		//Singleton
		if (Instance != null) {
			//someone else is a singleton already => destroy ourselves
			Destroy(this.gameObject);
			//test.text = "destroyed";
			return;
		}
		//we are the one
		Instance = this;
		GameObject.DontDestroyOnLoad (this.gameObject);
		playerInventory = new List<Item> ();
		GameState.characterInventory = new List<Character> ();
	}
		
	void OnDestroy(){
		Debug.Log ("GameStatus was destroyed");
	}
		
	public void addItem(Sprite icon, string text){
		
		Item newItem = new Item ();

		newItem.iconSprite = icon;
		newItem.itemName = text;

		playerInventory.Add(newItem);
	}

	public void addCharacter(Sprite icon, string text, string description){
		
		Character newCharacter = new Character ();

		newCharacter.characterSprite = icon;
		newCharacter.characterName = text;
		newCharacter.characterInfo = description;

		characterInventory.Add (newCharacter);
	}


	//test
	public List<Item> getPlayerInventory(){
		return playerInventory;
	}
	/*
	public string listItemNames(){
		string x = "";
		foreach (Item newItem in playerInventory) {
			x += newItem.returnName() + "+";
		}
		x += "END\n";
		return x;
	}
	*/
}
