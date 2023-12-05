using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorController : MonoBehaviour
{
    [SerializeField] GameObject bigPredatorPrefab;
    [SerializeField] GameObject smallPredatorPrefab;

    [SerializeField] float bigSpawnInterval = 30f;
    [SerializeField] float smallSpawnInterval = 5f;

    [SerializeField] float minSpawn;
    [SerializeField] float maxSpawn;
    [SerializeField] float smallMinSpawn;
    [SerializeField] float smallMaxSpawn;

    void Start()
    {
        // Spawn a big predator every 30 seconds
        InvokeRepeating(nameof(SpawnBig), bigSpawnInterval, bigSpawnInterval);

        // Spawn regular enemies every 5 seconds
        InvokeRepeating(nameof(SpawnSmall), smallSpawnInterval, smallSpawnInterval);
    }

    void Update()
    {

    }

    void SpawnBig()
    {
        var RandomX = Random.Range(minSpawn, maxSpawn);
        var RandomPosition = new Vector3(RandomX, transform.position.y);

        Instantiate(bigPredatorPrefab, RandomPosition, Quaternion.identity);
    }

    void SpawnSmall()
    {
        var RandomX = Random.Range(smallMinSpawn, smallMaxSpawn);
        var RandomPosition = new Vector3(RandomX, transform.position.y);

        Instantiate(smallPredatorPrefab, RandomPosition, Quaternion.identity);
    }
}
