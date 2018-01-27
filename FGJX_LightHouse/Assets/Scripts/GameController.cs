using System.Collections;
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

    void Start () {
        spawner = GetComponent<Spawner>();
    }
    void Update () {

    }


    void Save(){

    }
    void Load(){

    }





}