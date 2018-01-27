using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCubeController : MonoBehaviour {
	Renderer renderer;
	Material lightMat;
	float duration = 3;

	public Color onColor = Color.white;
    public Color offColor = Color.black;
	Color currentColor;

	public float currentIntensity = 3;
	public float onNum = 3;
    public float offNum = 0;

	//DynamicGI.SetEmissive(renderer, new Color(1f, 0.1f, 0.5f, 1.0f) * intensity)
	void Start () {
		lightMat = GetComponent<MeshRenderer>().material;
		renderer = GetComponent<Renderer>();
	}
	public void SwitchLight(bool turnOn){
		if(turnOn){
			currentIntensity = offNum;
			EaseLight(onColor, onNum);
		} else{
			currentIntensity = onNum;
			EaseLight(offColor, offNum);
		}
	}

	void EaseLight(Color endColor, float endEmission){
    	float startTime = Time.time;
		StartCoroutine(UpdateStat(startTime, lightMat.GetColor("_EmissionColor"), endColor, currentIntensity, endEmission));
	}
	IEnumerator UpdateStat(float startTime, Color startValue, Color endValue, float intensityStart, float intensityEnd){
		while(true){
			float t = (Time.time - startTime) / duration;
			Color colorLerp = Color.Lerp(startValue, endValue, t);
			float intensity = Mathf.Lerp(intensityStart, intensityEnd, t);
			//DynamicGI.SetEmissive(renderer, colorLerp * intensity);
			lightMat.SetColor("_EmissionColor", colorLerp * intensity);
			yield return null;
		}
	}
}
