using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomAndScroll : MonoBehaviour {

	Camera mainCamera;
	float touchesPrevPosDifference, touchesCurPosDifference, zoomModifier;
	Vector2 firstTouchPrevPos, secondTouchPrevPos;

	//public float zoomSpeed = 0.7f;
	//float prevDist;

	[SerializeField]
	float zoomModifierSpeed = 0.1f;

	[SerializeField]
	Text text;

	void Start(){
		mainCamera = GetComponent<Camera> ();
	}

	void Update () {
		if (Input.touchCount == 2) {

			UnityEngine.Touch firstTouch = Input.GetTouch (0);
			UnityEngine.Touch secondTouch = Input.GetTouch (1);

			firstTouchPrevPos = firstTouch.position - firstTouch.deltaPosition;
			secondTouchPrevPos = secondTouch.position - secondTouch.deltaPosition;

			touchesPrevPosDifference = (firstTouchPrevPos - secondTouchPrevPos).magnitude;
			touchesCurPosDifference = (firstTouch.position - secondTouch.position).magnitude;


			zoomModifier = (firstTouch.deltaPosition - secondTouch.deltaPosition).magnitude * zoomModifierSpeed;

			if (touchesPrevPosDifference > touchesCurPosDifference)
				mainCamera.orthographicSize += zoomModifier;
			if (touchesPrevPosDifference < touchesCurPosDifference)
				mainCamera.orthographicSize -= zoomModifier;
		}
		mainCamera.orthographicSize = Mathf.Clamp (mainCamera.orthographicSize, 2f, 10f);
	
		text.text = "Camera size " + mainCamera.orthographicSize;
	}
}
