using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetection : MonoBehaviour
{
    [SerializeField] private GameObject[] enemiesToSpawn;
    [SerializeField] private Collider2D currentSpawnableArea;
    [SerializeField] float bigSpawnInterval = 30f;
    [SerializeField] float smallSpawnInterval = 5f;
    private GameObject player;

    private Collider2D coll;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        coll = GetComponent<Collider2D>();

        // Spawn a big predator every 30 seconds
        InvokeRepeating(nameof(SpawnBigWithInterval), bigSpawnInterval, bigSpawnInterval);

        // Spawn regular enemies every 5 seconds
        InvokeRepeating(nameof(SpawnSmallWithInterval), smallSpawnInterval, smallSpawnInterval);

    }

    void SpawnBigWithInterval()
    {
        EnemySpawnManager.instance.SpawnBig(currentSpawnableArea);
    }

    void SpawnSmallWithInterval()
    {
        EnemySpawnManager.instance.SpawnSmall(currentSpawnableArea);
    }
}
