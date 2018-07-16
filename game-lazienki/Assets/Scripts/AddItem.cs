using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : MonoBehaviour {
	[SerializeField]
	private Sprite[] iconSprites;

	[SerializeField]
	private string[] itemText;

	public void AddItemToInventory(int nr){
		GameState.playerInventory = new List<Item> ();
		Item newItem = new Item ();

		newItem.iconSprite = iconSprites [nr];
		newItem.itemName = itemText[nr];

		GameState.playerInventory.Add (newItem);
	}
}