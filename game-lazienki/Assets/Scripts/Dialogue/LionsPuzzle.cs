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

	public Button Next;
	public Button Resign;

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

		if (gs.returnLion1()) {
			Lion1.image.sprite = checkedIcons [1];
			Lion1.enabled = false;
		}
		if (gs.returnLion2()) {
			Lion2.image.sprite = checkedIcons [1];
			Lion2.enabled = false;
		}
		if (gs.returnLion3()) {
			Lion3.image.sprite = checkedIcons [1];
			Lion3.enabled = false;
		}
		if (gs.returnLion4()) {
			Lion4.image.sprite = checkedIcons [1];
			Lion4.enabled = false;
		}

		enableNextButton (gs);
	}

	private void enableNextButton(GameState gs){

		if (gs.returnLion1 () && gs.returnLion2 () && gs.returnLion2 () && gs.returnLion3 () && gs.returnLion4 ()) {
			gs.updateLwy (1);
			Next.gameObject.SetActive (true);
			Resign.gameObject.SetActive (false);
		}
	
	}
	
}
