using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveMover : MonoBehaviour {

	public AnimationCurve positionCurve;
	Vector3 originalPosition;
	float t;

	public float speed = 1f;

	public Vector3 axesToAffect = new Vector3(1, 0, 1);
	public float amount = 0.5f;
	public float timeLimit = 1f;

	public bool setBackToOriginalPosition = true;
	bool isRunning = false;

	void Start(){
		originalPosition = transform.position;
	}

	public void OnTrigger(){
		if(!isRunning){
			Start();
			StartCoroutine(Shaker());
		}	
	}

	IEnumerator Shaker(){
		isRunning = true;
		t = 0;
		do{
			t += Time.deltaTime;
			float val = positionCurve.Evaluate(t * speed);
			transform.position = originalPosition + axesToAffect * amount * val;
			yield return null;
		}while(t < timeLimit);

		if(setBackToOriginalPosition) transform.position = originalPosition;
		isRunning = false;
	}
}
