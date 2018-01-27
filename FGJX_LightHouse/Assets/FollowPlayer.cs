using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	Transform player;
    Transform startTransform;
    UnityEngine.AI.NavMeshAgent agent;
    LightCubeController lightCubeController;

    MeshRenderer eyes;
    public float distanceLimit = 5f;
	
    void Start () {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startTransform = GameObject.FindGameObjectWithTag("EnemyStart").transform;
        eyes = transform.GetComponentInChildren<MeshRenderer>();
        lightCubeController = transform.GetComponentInChildren<LightCubeController>();
    }

    void Update () {
        EnemyLogic();
    }

    void EnemyLogic(){
        SetEnemyActivity(GameController.Instance.currentLightState);
        if(!GameController.Instance.currentLightState){
            
            Move();
            LookAtTarget(player); 
        } else{
            agent.isStopped = true;
        }
    }
    void SetEnemyActivity(bool activeState){
        if(activeState){
            if(eyes.enabled){
                StartCoroutine(WaitAndSwitch(lightCubeController.duration, false));
            } 
        } else{
            if(!eyes.enabled){
                StartCoroutine(WaitAndSwitch(lightCubeController.duration, true));
            } 
        }
    }
    IEnumerator WaitAndSwitch(float timeToWait, bool enabledState){
        WaitForSeconds delay = new WaitForSeconds(timeToWait);
        yield return delay;
        //lightCubeController.SwitchLight(enabledState);
        eyes.enabled = enabledState;
    }

    void Move(){
        if(Vector3.Distance(transform.position, player.position) > distanceLimit){
            agent.isStopped = false;
            agent.destination = player.position; 
        } else if(Vector3.Distance(transform.position, player.position) < distanceLimit){    
            agent.isStopped = false;
            agent.destination = startTransform.position; 
        } else{
            //agent.isStopped = true;
        }
    }

    void LookAtTarget(Transform target){
        transform.LookAt(target);
    }
}
