using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {

	public Transform target; // the object to rotate around
	public int speed; // the speed of rotation
	
	// Update is called once per frame
	void Update () {
		// RotateAround takes three arguments, first is the Vector to rotate around
		// second is a vector that axis to rotate around
		// third is the degrees to rotate, in this case the speed per second
		transform.RotateAround(target.transform.position,target.transform.up,speed * Time.deltaTime);
	}
}
