﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    private static GameController m_instance;
    public static GameController Instance{
        get{
            if (m_instance == null){
                m_instance = Component.FindObjectOfType<GameController>();
            }
            return m_instance;
        }
    }
    public Spawner spawner;
    GameData gameData;

    public List<LightController> lightHouseLights = new List<LightController>();
    public List<LightCubeController> lightHouseEmitters = new List<LightCubeController>();
    bool currentLightState = true;
    public float lightWaitTime = 5f;

    void Start () {
        spawner = GetComponent<Spawner>();
        StartCoroutine(ToggleLights());
    }





    void Update () {

    }


    void Save(){

    }
    void Load(){

    }

    IEnumerator ToggleLights(){
        WaitForSeconds waitTime = new WaitForSeconds(lightWaitTime);
        while(true){
            yield return waitTime;
            TurnLights(!currentLightState);
        }
    }
    void TurnLights(bool state){
        foreach(LightController lc in lightHouseLights){
            lc.SwitchLight(state);
        }
        foreach(LightCubeController lcc in lightHouseEmitters){
            lcc.SwitchLight(state);
        }

        currentLightState = state;
    }



}