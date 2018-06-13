using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryControl : MonoBehaviour {

	public List<Item> playerInventory;

	[SerializeField]
	private GameObject itemTemplate;

	[SerializeField]
	private GridLayoutGroup gridGroup;

	[SerializeField]
	private Sprite[] iconSprites;

	[SerializeField]
	private string[] itemText;


	void Start(){

		playerInventory = new List<Item> ();

		for (int i = 0; i < 10; i++) {

				Item newItem = new Item ();
				
				newItem.iconSprite = iconSprites [0];
				newItem.itemName = itemText[0];

				playerInventory.Add (newItem);
			}
		GenerateInventory ();
	}

	void GenerateInventory(){
		int i = 1;
		foreach (Item newItem in playerInventory){
			GameObject item = Instantiate (itemTemplate) as GameObject;
			item.SetActive (true);

			//Generating Items in Inventory
			item.GetComponent <InventoryItem>().SetText (newItem.itemName);
			item.GetComponent <InventoryItem> ().SetIcon (newItem.iconSprite);

			item.transform.SetParent (itemTemplate.transform.parent, false); //parent the same as for  itemTemplate
			i++;
		}
	}
}
