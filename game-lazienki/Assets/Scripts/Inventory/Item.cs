﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item : MonoBehaviour {
	public string itemName;
	public int itemID;
	public Sprite iconSprite;

	//public ItemType itemType;

	public string returnName(){
		return itemName;
	}
	/*
	public enum ItemType{
		Weapon,
		Food
	}
	*/
}