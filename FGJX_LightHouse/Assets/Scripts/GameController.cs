using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public bool currentLightState = true;
    public float lightWaitTime = 5f;

    public Transform[] enemySpawnPositions;
    public GameObject enemy;

    public GameObject[] Modes = new GameObject[2];
    int current = 0;

    public Fade fader;
    bool switchLights = true; 
    public GameObject lightToTurnOFF;

    int enemyCounter = 0;

    void Start () {
        spawner = GetComponent<Spawner>();
        StartCoroutine(ToggleLights());
    }


    void Update () {

    }

    IEnumerator ToggleLights(){
        WaitForSeconds waitTime = new WaitForSeconds(lightWaitTime);
        while(switchLights){
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

    public void SpawnEnemy(){
        spawner.Spawn(enemy, enemySpawnPositions[enemyCounter].position);
        enemyCounter++;
    }

    public void StartChangeMode(){
        StartCoroutine(ChangeTimer());
    }
    IEnumerator ChangeTimer(){
        fader.FadeIn();
        yield return new WaitForSeconds(2);
        switchLights = false;
        lightToTurnOFF.SetActive(false);
        ChangeMode();
        fader.FadeOut();
    
    }
    void ChangeMode(){
        Modes [current].SetActive (false);

        if (current + 1 < Modes.Length) {
            current += 1;
            Modes [current].SetActive (true);
            StartEnd();

        } else {
            current = 0;
            Modes [current].SetActive (true);
        }
    }
    IEnumerator StartEnd(){
        yield return new WaitForSeconds(7f);
        fader.FadeIn();
        yield return new WaitForSeconds(1f);
        EndGame();
    }
    void EndGame(){
        //SceneManager.LoadScene("Menu");

    }

    public void PlayerDead(){
        StartCoroutine(DoPlayerDead());
    }

    IEnumerator DoPlayerDead(){
        fader.FadeIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Game");
    }

}