using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : MonoBehaviour {
		
	// Update is called once per frame
	public void TakeItem (int nr) {
		GameState.Instance.AddItem (nr);
	}
}