using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemyTemplate;
    [SerializeField] private int _spawnCount;
    [SerializeField] private TimeShift _timeshift;
    [SerializeField] private GameObject _container;
    private List<SpawnPoints> _spawnPoints = new List<SpawnPoints>();
    private List<Enemy> _spawnedEnemies;




    private void Start()
    {
        _spawnPoints.AddRange(GetComponentsInChildren<SpawnPoints>());
        SpawnAndDisabled();
    }

    private void SpawnAndDisabled()
    {
        for (int i = 0; i < _spawnCount; i++)
        {
            SpawnPoints point = GetRandomPoint();
            Enemy enemy = Instantiate(GetRandomEnemy(), point.transform.position, point.transform.rotation);
            enemy.gameObject.transform.parent = _container.transform;
            enemy.Init(_timeshift);
            enemy.gameObject.SetActive(true);
            point.gameObject.SetActive(false);
            _spawnPoints.Remove(point);
        }

        Debug.Log("EndSpawn");
    }

    private Enemy GetRandomEnemy()
    {
        return _enemyTemplate[Random.Range(0, _enemyTemplate.Count)];
    }

    private SpawnPoints GetRandomPoint()
    {
        return _spawnPoints[Random.Range(0, _spawnPoints.Count)];
    }
}
