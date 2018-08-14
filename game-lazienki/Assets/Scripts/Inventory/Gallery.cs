using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gallery : MonoBehaviour {

	[SerializeField]
	private Sprite[] pictures;

	public Image frame;
	int current = 0;

	void Start () {
		frame.sprite = pictures [current];
	}

	void Update () {
		frame.sprite = pictures [current];
	}

	public void Next(){
		if (current + 1 < pictures.Length)
			current += 1;
		else
			current = 0;
	}

	public void Previous(){
		if (current - 1 > 0)
			current -= 1;
		else
			current = pictures.Length;
	}
}
