using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void NewGame (){
		SceneManager.LoadScene (1);
	}

	public void ContinueGame (){
		SceneManager.LoadScene (1);
	}

	public void AboutGame (){
		SceneManager.LoadScene (6);
	}

	public void QuitGame (){
		Debug.Log ("QUIT");
		Application.Quit ();
	}
}
