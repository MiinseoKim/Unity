using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public GameObject EnemyPrefab;
    public float SpawnTime = 3;

    public Transform[] SpawnArray;
	void Start ()
    {
        InvokeRepeating("Spawn", SpawnTime, SpawnTime);
	}
	void Spawn()
    {
        int randIndex = Random.Range(0, SpawnArray.Length);
        Instantiate(EnemyPrefab, SpawnArray[randIndex].position,
            SpawnArray[randIndex].rotation);
    }
}
