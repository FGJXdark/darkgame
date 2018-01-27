using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    private static Spawner m_instance;
    public static Spawner Instance{
        get{
            if (m_instance == null){
                m_instance = Component.FindObjectOfType<Spawner>();
            }
            return m_instance;
        }
    }
    public void Spawn(GameObject toSpawn, Vector3 position){
        Instantiate(toSpawn, position, Quaternion.identity);
    }
    public void Spawn(GameObject toSpawn, Vector3 position, Transform parent){
        Instantiate(toSpawn, position, Quaternion.identity, parent);
    }
    public GameObject SpawnGO(GameObject toSpawn, Vector3 position){
        GameObject GO = Instantiate(toSpawn, position, Quaternion.identity);
        return GO;
    }
    public GameObject SpawnGO(GameObject toSpawn, Vector3 position, Transform parent){
        GameObject GO = Instantiate(toSpawn, position, Quaternion.identity, parent);
        return GO;
    }
}