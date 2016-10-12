using UnityEngine;
using System.Collections;

// ----------------------- //
// This class only needs a //
// start method, as all of //
// it's code needs to run  //
// when the level starts   //
// ----------------------- //
public class GM : MonoBehaviour {

	// Use this for initialization
	void Start() {
	
		// Upon further review, we have decided to lower the framerate to 60
		Application.targetFrameRate = /* 9001 */ 60;

	}

}
