using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private Mover[] _moverObjectTemplates;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;

    private WaitForSeconds _waitForSpawn;
    private GameObject[] _spawnableObjects;

    private void Awake()
    {
        _waitForSpawn = new WaitForSeconds(_secondsBetweenSpawn);
    }

    private void Start()
    {
        _spawnableObjects = _moverObjectTemplates.Select(spawnableObject => spawnableObject.gameObject).ToArray();
        Initialize(_spawnableObjects);
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (Time.timeScale != 0)
        {
            if (TryGetObject(out GameObject spawnableObject))
            {
                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                SetSpawnableObject(spawnableObject, _spawnPoints[spawnPointNumber].position);
            }

            yield return _waitForSpawn;
        }
    }

    private void SetSpawnableObject(GameObject spawnableObject, Vector3 spawnPoint)
    {
        spawnableObject.transform.position = spawnPoint;
        spawnableObject.gameObject.SetActive(true);
    }
}
