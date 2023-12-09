using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{
    [SerializeField] GameObject[] _shellPrefab;
    [SerializeField] float _spawnInterval = 40f;
    [SerializeField] float _minSpawn;
    [SerializeField] float _maxSpawn;

    void Start()
    {
        InvokeRepeating(nameof(ShellSpawn), _spawnInterval, _spawnInterval);
    }

    void Update()
    {

    }

    void ShellSpawn()
    {
        var Randomize = Random.Range(_minSpawn, _maxSpawn);
        var RandomPosition = new Vector3(Randomize, transform.position.y);

        Instantiate(_shellPrefab[Random.Range(0, _shellPrefab.Length)], RandomPosition, Quaternion.identity);
    }
}
