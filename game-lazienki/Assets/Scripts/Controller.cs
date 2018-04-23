using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wikitude;

public class Controller : MonoBehaviour {

	public InstantTracker Tracker;
	private float heightAboveGround = 1.0f;
	private GridRenderer grid;
	private bool isTracking = false;

	//wlacz/wylacz tracking
	public Button trackingControl;
	public GameObject prefab;


	public void Awake(){
		grid = GetComponent<GridRenderer> ();
	}

	// Start Tracking after pressing button
	public void StartTracker(){
		isTracking = !isTracking;
		if (isTracking)
			Tracker.SetState (InstantTrackingState.Tracking);
		else
			Tracker.SetState (InstantTrackingState.Initializing);

		Tracker.DeviceHeightAboveGround = heightAboveGround;
	}

	//Functions enabling and disabling grid
	public void OnEnterFieldOfVision (string target){
		grid.enabled = true;
	}

	public void OnExitFieldOfVision(string target){
		grid.enabled = false;
	}

	// Tracker events
	public virtual void OnTargetLoaded(){
		Debug.Log ("Targets loaded successfully");
	}

	public void OnStateChange(InstantTrackingState newState){
		Debug.Log ("State changes to" + newState);
		if (newState == InstantTrackingState.Tracking) {
			isTracking = true;
			//change button collor while tracking
			trackingControl.GetComponent<Image> ().color = Color.green;
		} 
		else if (newState == InstantTrackingState.Initializing) {
			isTracking = false;
			//change button collor while tracking
			trackingControl.GetComponent<Image> ().color = Color.red;
		}
	}

	void Update(){
		if (!isTracking)
			return;
		/*
		if (Input.GetTouch (0).tapCount == 2) {
			GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			sphere.transform.position = Camera.main.transform.position;
		}
		*/
		/*
		var ray = Camera.main.ScreenPointToRay (Touch.position); 
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
			if (Physics.Raycast (ray, RaycastHit, 100))
				Debug.DrawLine (ray.origin, RaycastHit.point);
		}
		*/
	}

}
