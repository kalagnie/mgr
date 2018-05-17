using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour {

	public Button distanceControl;

	public void Update(){
		if (GPS.Instance.isCloseEnough)
			distanceControl.GetComponent<Image> ().color = Color.green;
		else
			distanceControl.GetComponent<Image> ().color = Color.red;
	}
}
