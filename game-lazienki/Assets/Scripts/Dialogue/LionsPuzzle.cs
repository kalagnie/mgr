using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LionsPuzzle : MonoBehaviour {

	public Button Lion1;
	public Button Lion2;
	public Button Lion3;
	public Button Lion4;

	[SerializeField]
	private Sprite[] checkedIcons;

	// Use this for initialization
	void Start () {
		Lion1.image.sprite = checkedIcons [0];
		Lion2.image.sprite = checkedIcons [0];
		Lion3.image.sprite = checkedIcons [0];
		Lion4.image.sprite = checkedIcons [0];
	}
	
	// Update is called once per frame
	void Update () {
		GameObject go = GameObject.Find("GameState");
		if(go == null){
			Debug.LogError("Failed to find 'GameState' object");
			this.enabled = false;
			return;
		}

		GameState gs = go.GetComponent<GameState>();

		if (gs.returnCheckedLions () [0] == 1) {
			Lion1.image.sprite = checkedIcons [1];
			Lion1.enabled = false;
		}
		if (gs.returnCheckedLions () [1] == 1) {
			Lion1.image.sprite = checkedIcons [1];
			Lion1.enabled = false;
		}
		if (gs.returnCheckedLions () [2] == 1) {
			Lion1.image.sprite = checkedIcons [1];
			Lion1.enabled = false;
		}
		if (gs.returnCheckedLions () [3] == 1) {
			Lion1.image.sprite = checkedIcons [1];
			Lion1.enabled = false;
		}
	}
}
