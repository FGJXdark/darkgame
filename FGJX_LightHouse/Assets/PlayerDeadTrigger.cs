using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadTrigger : MonoBehaviour {

	bool doOnce = true;
	void OnTriggerEnter(Collider coll){
		if(doOnce && coll.gameObject.tag == "Player") {
			GameController.Instance.PlayerDead();
			doOnce = false;
		}
	}
}
