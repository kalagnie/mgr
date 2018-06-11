﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryControl : MonoBehaviour {

	//private List<Item> playerInventory;
	public List<Item> playerInventory;

	[SerializeField]
	private GameObject itemTemplate;

	[SerializeField]
	private GridLayoutGroup gridGroup;

	[SerializeField]
	private Sprite[] iconSprites;

	/*
	public class PlayerItem{
		public Sprite iconSprite;
		public Texture iconText;
	}
	*/

	void Start(){

		playerInventory = new List<Item> ();

		for (int i = 1; i <= 20; i++) {

			Item newItem = new Item ();
			newItem.iconSprite = iconSprites [Random.Range (0, iconSprites.Length)];

			playerInventory.Add (newItem);
		}

		GenerateInventory ();
	}

	void GenerateInventory(){
		int i = 1;
		foreach (Item newItem in playerInventory){
			GameObject item = Instantiate (itemTemplate) as GameObject;
			item.SetActive (true);

			item.GetComponent <InventoryItem>().SetText ("Item " + i);
			item.GetComponent <InventoryItem> ().SetIcon (newItem.iconSprite);

			item.transform.SetParent (itemTemplate.transform.parent, false); //parent the same as for  itemTemplate
			i++;
		}
	}
}