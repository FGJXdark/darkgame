using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

	Light lightSetting;
	float duration = 3;

	public float onNum = 100;
    public float offNum = 0;

	void Start () {
		lightSetting = GetComponent<Light>();
	}
	public void SwitchLight(bool turnOn){
		if(turnOn){
			EaseLight(onNum);
		} else{
			EaseLight(offNum);
		}
	}

	void EaseLight(float endValue){
    	float startTime = Time.time;
		StartCoroutine(UpdateStat(startTime, lightSetting.intensity, endValue));
	}

	IEnumerator UpdateStat(float startTime, float startValue, float endValue){	
		while(true){
			float t = (Time.time - startTime) / duration;
			lightSetting.intensity = Mathf.SmoothStep(startValue, endValue, t);
			yield return null;
		}
	}
	
}
