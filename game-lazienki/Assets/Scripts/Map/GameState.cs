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

	//visited characters
	static public int visitedChopin;
	static public int visitedSienkiewicz;
	static public int visitedSobieski;
	static public int visitedStanislaw;
	static public int visitedLwy;

	static public bool Lion1;
	static public bool Lion2;
	static public bool Lion3;
	static public bool Lion4;

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

		visitedChopin = 0;
		visitedSienkiewicz = 0;
		visitedSobieski = 0;
		visitedStanislaw = 0;
		visitedLwy = 0;

		Lion1 = false;
		Lion2 = false;
		Lion3 = false;
		Lion4 = false;
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

	public void removeItem (string name){

		int a = playerInventory.FindIndex (x => x.itemName.Equals (name));
		playerInventory.Remove (playerInventory[a]);
	}

	public bool checkForItem(string name){
		return playerInventory.Exists (x => x.itemName.Equals(name));
	}

	//update character status
	public void updateChopin(int n){
		visitedChopin = n;
	}

	public void updateSienkiewicz(int n){
		visitedSienkiewicz = n;
	}

	public void updateSobieski(int n){
		visitedSobieski = n;
	}

	public void updateStanislaw(int n){
		visitedStanislaw = n;
	}

	public void updateLwy(int n){
		visitedLwy = n;
	}

	public void updateLion1(){
		Lion1 = true;
	}
	public void updateLion2(){
		Lion2 = true;
	}
	public void updateLion3(){
		Lion3 = true;
	}
	public void updateLion4(){
		Lion4 = true;
	}
		
	//return character status
	public int returnChopin(){
		return visitedSobieski;
	}

	public int returnSienkiewicz(){
		return visitedSobieski;
	}

	public int returnSobieski(){
		return visitedSobieski;
	}

	public int returnStanislaw(){
		return visitedSobieski;
	}

	public int returnLwy(){
		return visitedLwy;
	}
		
	public bool returnLion1(){
		return Lion1;
	}
	public bool returnLion2(){
		return Lion2;
	}
	public bool returnLion3(){
		return Lion3;
	}
	public bool returnLion4(){
		return Lion4;
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
