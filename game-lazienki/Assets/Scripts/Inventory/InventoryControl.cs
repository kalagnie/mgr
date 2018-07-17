using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryControl : MonoBehaviour {

	//public List<Item> playerInventory;

	[SerializeField]
	private GameObject itemTemplate;

	[SerializeField]
	private GridLayoutGroup gridGroup;

	void Start(){
		GenerateInventory ();
	}
		
	void GenerateInventory(){
		int i = 1;
		GameObject go = GameObject.Find("GameState");
		if(go == null){
			Debug.LogError("Failed to find 'GameState' object");
			this.enabled = false;
			return;
		}

		GameState gs = go.GetComponent<GameState>();
		List<Item> inventory = gs.getPlayerInventory ();

		foreach (Item newItem in inventory){
			GameObject item = Instantiate (itemTemplate) as GameObject;
			item.SetActive (true);

			//Generating Items in Inventory
			item.GetComponent <InventoryItem>().SetText (newItem.itemName);
			item.GetComponent <InventoryItem> ().SetIcon (newItem.iconSprite);

			item.transform.SetParent (itemTemplate.transform.parent, false); //parent the same as for itemTemplate
			i++;
		}
	}

}
