using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour {
	
	[SerializeField]
	private Text itemText;

	[SerializeField]
	private Image itemIcon;

	public void SetText(string textString){
		itemText.text = textString;
	}

	public void SetIcon(Sprite itemSprite){
		itemIcon.sprite = itemSprite;
	}
}
