using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

	
	void Start () {
		RotateRandom();
	}
	
	void RotateRandom(){
		transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));
	}
	
}
