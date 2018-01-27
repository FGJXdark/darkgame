using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimation : MonoBehaviour {

	List<SkinnedMeshRenderer> shapes = new List<SkinnedMeshRenderer>();
	public float animationDuration = 30;

	void Start () {
		GetChildComponents();
		StartCoroutine(PlayAnimation(Time.time, 0, 100));
	}
	
	void GetChildComponents(){
		foreach(Transform child in transform){
			shapes.Add(child.GetComponent<SkinnedMeshRenderer>());
		}
	}

	IEnumerator PlayAnimation(float startTime, float startValue, float endValue){	
		while(true){
			float t = (Time.time - startTime) / animationDuration;
			float weight = Mathf.SmoothStep(startValue, endValue, t);
			foreach(SkinnedMeshRenderer shape in shapes){
				shape.SetBlendShapeWeight(0, weight);
			}
			yield return null;
		}
	}
	
}
