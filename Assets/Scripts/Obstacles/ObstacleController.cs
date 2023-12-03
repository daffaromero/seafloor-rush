using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] GameObject[] _obstaclePrefab;
    [SerializeField] float _spawnInterval = 20f;
    [SerializeField] float _minSpawn;
    [SerializeField] float _maxSpawn;

    void Start()
    {
        InvokeRepeating(nameof(ObstacleSpawn), _spawnInterval, _spawnInterval);
    }

    void Update()
    {

    }

    void ObstacleSpawn()
    {
        var Randomize = Random.Range(_minSpawn, _maxSpawn);
        var RandomPosition = new Vector3(Randomize, transform.position.y);

        Instantiate(_obstaclePrefab[Random.Range(0, _obstaclePrefab.Length)], RandomPosition, Quaternion.identity);
    }
}
