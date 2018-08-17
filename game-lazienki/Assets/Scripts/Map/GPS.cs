using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GPS : MonoBehaviour {

	public static GPS Instance { set; get; }

	public bool isCloseEnough;

	public double latitude;
	public double longitude;

	//przyciski
	public Button Chopin;
	public Button Sobieski;
	public Button Stanislaw;

	public Button PalacNaWyspie;
	public Button BialyDomek;
	public Button Kartusz;
	public Button StaraKordegarda;
	public Button PalacMyslewicki;
	public Button SwiatyniaSybilli;
	public Button SwiatyniaEgipska;
	public Button Lwy;

	public Button Rembrandt;

	public Button Coins;
	public Button Coins2;
	public Button Crown;

	public Button Music1;
	public Button Music2;

	public Button FinalPoint;
	public Text WinText;
	public Button BackWinPanel;
	public Button QuitWinPanel;

	//wspolrzedne punktow

	//dom
	double fi2 = 52.17731867467772;
	double lambda2 = 21.05153060884163;

	//character's coordinations
	double ChopinF = 52.214703;
	double ChopinL = 21.028105;

	double SobieskiF = 52.217499;
	double SobieskiL = 21.035456;

	double StanislawF = 52.215630;
	double StanislawL = 21.031462;

	//place's coordinations
	double PalacNaWyspieF = 52.215063;
	double PalacNaWyspieL = 21.035809;

	double BialyDomekF = 52.215320;
	double BialyDomekL = 21.031528;

	double KartuszF = 52.217065;
	double KartuszL = 21.036387;

	double StaraKordegardaF = 52.216238;
	double StaraKordegardaL = 21.036647;

	double PalacMyslewickiF = 52.215498;
	double PalacMyslewickiL = 21.038291;

	double SwiatyniaSybilliF = 52.213726;
	double SwiatyniaSybilliL = 21.029000;

	double SwiatyniaEgipskaF = 52.211166;
	double SwiatyniaEgipskaL = 21.028991;

	//items
	double RembrandtF = 52.214577;
	double RembrandtL = 21.026379;

	double CoinsF = 52.212193;
	double CoinsL = 21.037555;

	double Coins2F = 52.211341;
	double Coins2L = 21.033561;

	double CrownF = 52.209586;
	double CrownL = 21.033650;

	double Music1F = 52.213809;
	double Music1L = 21.033776;

	double Music2F = 52.213276;
	double Music2L = 21.028133;

	//test
	public Text test;
	public Text testH;

	private void Start () {
		Instance = this;
		DontDestroyOnLoad (gameObject);
		StartCoroutine (StartLocationService ());

	}

	private IEnumerator StartLocationService(){
		if (!Input.location.isEnabledByUser) {
			Debug.Log ("User has not enabled GPS");
			yield break;
		}

		Input.location.Start();
		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0){
			yield return new WaitForSeconds (1);
			maxWait--;
		}

		if (maxWait <= 0) {
			Debug.Log ("Timed out");
			yield break;
		}

		if (Input.location.status == LocationServiceStatus.Failed) {
			Debug.Log ("Unable to determine device location");
			yield break;
		}

		latitude = Input.location.lastData.latitude;
		longitude = Input.location.lastData.longitude;

		checkObjects ();

		yield break;
	}

	private void checkObjects(){
		GameObject go = GameObject.Find("GameState");
		if(go == null){
			Debug.LogError("Failed to find 'GameState' object");
			this.enabled = false;
			return;
		}

		GameState gs = go.GetComponent<GameState>();

		characterActivation (Sobieski, SobieskiF, SobieskiL, gs.returnSobieski ());
		characterActivation (Chopin, ChopinF, ChopinL, gs.returnChopin());
		characterActivation (Sobieski, SobieskiF, SobieskiL, gs.returnSobieski());
		characterActivation (Stanislaw, StanislawF, StanislawL, gs.returnStanislaw());
		characterActivation (Lwy, SwiatyniaEgipskaF, SwiatyniaEgipskaL, gs.returnLwy());

		placeActivation (PalacNaWyspie, PalacNaWyspieF, PalacNaWyspieL);
		placeActivation (BialyDomek, BialyDomekF, BialyDomekL);
		placeActivation (Kartusz, KartuszF, KartuszL);
		placeActivation (StaraKordegarda, StaraKordegardaF, StaraKordegardaL);
		placeActivation (PalacMyslewicki, PalacMyslewickiF, PalacMyslewickiL);
		placeActivation (SwiatyniaSybilli, SwiatyniaSybilliF, SwiatyniaSybilliL);
		placeActivation (SwiatyniaEgipska, SwiatyniaEgipskaF, SwiatyniaEgipskaL);

		placeActivation (Coins, CoinsF, CoinsL);
		placeActivation (Coins2, Coins2F, Coins2L);
		objectActivation (Crown, CrownF, CrownL, gs.returnCrown());
		objectActivation (Rembrandt, RembrandtF, RembrandtL, gs.returnRembrandt());

		placeActivation (Music1, Music1F, Music1L);
		placeActivation (Music2, Music2F, Music2L);

		FinalPointActivation (FinalPoint, PalacNaWyspieF, PalacNaWyspieL, gs.returnLwy());
		//FinalPointActivation (FinalPoint, fi2, lambda2, gs.returnLwy());
	}

	private void characterActivation(Button b, double f, double l, int visited){
		if (CalculatingDistance (latitude, longitude, f, l) && (visited != 2))
			b.interactable = true;
		else
			b.interactable = true; //for testing
			//b.interactable = false;
	}

	private void placeActivation(Button b, double f, double l){
		if (CalculatingDistance (latitude, longitude, f, l))
			b.interactable = true;
		else
			b.interactable = true; //for testing
			//b.interactable = false;
	}

	private void objectActivation(Button b, double f, double l, bool taken){
		if (!taken) {
			if (CalculatingDistance (latitude, longitude, f, l))
				b.interactable = true;
			else
				b.interactable = true; //for testing
			//b.interactable = false;
		} else
			b.gameObject.SetActive (false);
	}

	private void FinalPointActivation(Button b, double f, double l, int visited){
		if (visited == 2){
			
			b.gameObject.SetActive (true);

			//if (CalculatingDistance (latitude, longitude, f, l)) {
				b.interactable = true;
				GameObject go = GameObject.Find ("GameState");
				if (go == null) {
					Debug.LogError ("Failed to find 'GameState' object");
					this.enabled = false;
					return;
				}

				GameState gs = go.GetComponent<GameState> ();


				if (gs.returnCrown () && gs.returnApple () && gs.returnSceptre ()) {
					
					WinText.text = "Trafiłeś w tunel czasoprzestrzenny i... wróciłeś do swoich czasów! Gratulacje!";
					BackWinPanel.gameObject.SetActive (false);
					QuitWinPanel.gameObject.SetActive (true);
				}
				else
					WinText.text = "Znajdż insygnia władzy królewskiej, by wygrać grę.";
			//}
			//else
				//b.interactable = false;
		}
		else
			b.gameObject.SetActive (false);
	}

	private double CosineLaw(double fi1, double lambda1, double fi2, double lambda2, double R){
		var deltaLambda = lambda1 - lambda2;
		var cosc = Math.Sin (fi1) * Math.Sin (fi2) + Math.Cos (fi1) * Math.Cos (fi2) * Math.Cos (deltaLambda);
		var distance = Math.Acos (cosc) * R;

		return distance;
	}

	private double HaversineFormula(double fi1, double lambda1, double fi2, double lambda2, double R){

		var deltaFi = fi1 - fi2;
		var deltaLambda = lambda1 - lambda2;

		//a = haversine
		var a = Math.Sin (deltaFi / 2) * Math.Sin (deltaFi / 2) + Math.Cos (fi1) * Math.Cos (fi2) * Math.Sin (deltaLambda / 2) * Math.Sin (deltaLambda / 2);
		//formula, *1000 => conversion to metres
		var distance = 2 * R * Math.Atan2 (Math.Sqrt(a), Math.Sqrt(1-a));

		return distance;
	}

	private bool CalculatingDistance (double fi1, double lambda1, double fi2, double lambda2){

		var R = 6378.137; //promien Ziemi w km

		var d = HaversineFormula (fi1, lambda1, fi2, lambda2, R);
		var distance = CosineLaw (fi1, lambda1, fi2, lambda2, R);


		//Haversine
		if (distance <= 2.0) {
			testH.text = "Haversine\n" + d + " true";
		} else {
			testH.text = "Haversine\n" + d + " false";
		}

		//Cosine Law
		if (distance <= 2.0) {
			Debug.Log ("true");
			test.text = "Cosine Law\n" + distance + " true";
			return true;
		} else {
			test.text = "Cosine Law\n" + distance + " false";
			return false;
		}

	}

	private void Update(){
		latitude = Input.location.lastData.latitude;
		longitude = Input.location.lastData.longitude;

		checkObjects();
	}
}
