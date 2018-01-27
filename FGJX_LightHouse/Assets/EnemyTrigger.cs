using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour {

	bool doOnce = true;
	void OnTriggerEnter(Collider coll){
		if(doOnce && coll.gameObject.tag == "Player") {
			GameController.Instance.SpawnEnemy();
			doOnce = false;
		}
	}
}
