using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item : MonoBehaviour {
	public string itemName;
	public int itemID;
	public string itemDesc;
	//public Texture2D itemIcon;
	public Sprite iconSprite;
	public ItemType itemType;

	public enum ItemType{
		Weapon,
		Food
	}
}
