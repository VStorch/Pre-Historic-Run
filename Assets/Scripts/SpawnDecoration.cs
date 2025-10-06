using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDecoration : MonoBehaviour
{
    public GameObject[] decorations;
    public float minSpawnTime = 7f, maxSpawnTime = 20f;
    public float baseSpeed = 0.5f;

    private float timer, nextSpawn;

    void Start()
    {
        SetNextSpawn();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > nextSpawn)
        {
            timer = 0;
            SetNextSpawn();
            int index = Random.Range(0, decorations.Length);
            Instantiate(decorations[index], transform.position, Quaternion.identity);
        }
    }

    void SetNextSpawn()
    {
        nextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }

}
