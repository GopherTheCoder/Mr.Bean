using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnDelay;
    public float spawnInterval;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start() => InvokeRepeating("Spawn", spawnDelay, spawnInterval);

    private void Spawn()
    {
        Instantiate(enemy, transform);
    }
}
