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

		isCloseEnough = CalculatingDistance (latitude, longitude);

		yield break;
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

	private bool CalculatingDistance (double fi1, double lambda1){
		//zdefiniowany punkt, do ktorego mierzymy odleglosc
		//var fi2 = 52.17731867467772;
		//var lambda2 = 21.05153060884163;
		var fi2 = 52.17696367924449;
		var lambda2 = 21.035835875788166;

		var R = 6378.137; //promien Ziemi w km

		var d = HaversineFormula (fi1, lambda1, fi2, lambda2, R);
		var distance = CosineLaw (fi1, lambda1, fi2, lambda2, R);

		//Haversine
		if (distance <= 10.0) {
			testH.text = "Haversine\n" + d + " true";
		} else {
			testH.text = "Haversine\n" + d + " false";
		}

		//Cosine Law
		if (distance <= 10.0) {
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

		isCloseEnough = CalculatingDistance (latitude, longitude);
	}

}
