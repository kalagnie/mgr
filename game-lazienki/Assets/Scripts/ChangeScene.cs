﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
	
	public void ChangeToScene (int newScene){
		SceneManager.LoadScene (newScene);
	}

	public void EndGame (){
		Application.Quit ();
	}
}
