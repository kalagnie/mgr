using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//test
using UnityEngine.UI;

public class GameState : MonoBehaviour {

	static public GameState Instance; //The right GameStatus { set; get; }

	//List of characters and list of items
	static public List<Item> playerInventory;
	static public List<Character> characterInventory;

	//test
	public Text test;

	void Start(){
		//Singleton
		if (Instance != null) {
			//someone else is a singleton already => destroy ourselves
			Destroy(this.gameObject);
			return;
		}
		//we are the one
		Instance = this;
		//GameObject.FindObjectOfType<GameState>();
		GameObject.DontDestroyOnLoad (this.gameObject);
	}

	void Update(){
		//test.text = playerInventory.GetEnumerator.toString ();
		foreach (Item newItem in GameState.playerInventory) {
			test.text += newItem.itemName + "/n";
		}
	}

	void OnDestroy(){
		Debug.Log ("GameStatus was destroyed");
	}
		
}
