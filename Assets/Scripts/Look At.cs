using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LookAtTarget : MonoBehaviour {

	static public GameObject target; // the target that the camera should look at

	
	
	// Update is called once per frame
	void Update () {
		if (target) transform.LookAt(target.transform);
	}
}
