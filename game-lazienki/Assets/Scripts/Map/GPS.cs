using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GPS : MonoBehaviour {

	public static GPS Instance { set; get; }

	public double latitude;
	public double longitude;
	public bool isCloseEnough;

	//przyciski
	public Button Chopin;
	public Button Sienkiewicz;
	public Button Sobieski;
	public Button Stanislaw;

	public Button PalacNaWodzie;
	public Button BialyDomek;

	//wspolrzedne punktow

	//dom
	double fi2 = 52.17731867467772;
	double lambda2 = 21.05153060884163;

	double ChopinF = 52.214703;
	double ChopinL = 21.028105;

	double SienkiewiczF = 52.215659;
	double SienkiewiczL = 21.027031;

	double SobieskiF = 52.217499;
	double SobieskiL = 21.035456;

	double StanislawF = 52.215630;
	double StanislawL = 21.031462;

	double PalacNaWodzieF = 52.215069;
	double PalacNaWodzieL = 21.035814;

	double BialyDomekF = 52.215314;
	double BialyDomekL = 21.031519;

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
		//test
		//isCloseEnough = CalculatingDistance (latitude, longitude, fi2, lambda2);
		buttonActivation (Chopin, fi2, lambda2);

		//buttonActivation (Chopin, ChopinF, ChopinL);
		buttonActivation (Sienkiewicz, SienkiewiczF, SienkiewiczL);
		buttonActivation (Sobieski, SobieskiF, SobieskiL);
		buttonActivation (Stanislaw, StanislawF, StanislawL);

		buttonActivation (PalacNaWodzie, PalacNaWodzieF, PalacNaWodzieL);
		buttonActivation (BialyDomek, BialyDomekF, BialyDomekL);
	}

	private void buttonActivation(Button b, double f, double l){
		if (CalculatingDistance (latitude, longitude, f, l))
			b.interactable = true;
		else
			b.interactable = false;
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

		//isCloseEnough = CalculatingDistance (latitude, longitude, fi2, lambda2);
		checkObjects();
	}
}
