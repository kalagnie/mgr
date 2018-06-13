using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterList : MonoBehaviour {

	[SerializeField]
	private Text characterName;

	[SerializeField]
	private Text characterDescr;

	[SerializeField]
	private Image characterIcon;

	public void SetText(string textString){
		characterName.text = textString;
	}

	public void SetIcon(Sprite itemSprite){
		characterIcon.sprite = itemSprite;
	}

	public void SetDescription(string textString){
		characterDescr.text = textString;
	}
}
