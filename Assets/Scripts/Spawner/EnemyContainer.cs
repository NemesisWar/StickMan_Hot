using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyContainer : MonoBehaviour
{
    [SerializeField] private GameVisitor _gameVisior;
    private List <Enemy> _enemies = new List<Enemy>();
    private Spawner _spawner;

    private void Awake()
    {
        _spawner = FindObjectOfType<Spawner>();
    }

    private void OnEnable()
    {
        _spawner.SpawnFinished += OnSpawnFinished;
    }

    private void OnDisable()
    {
        _spawner.SpawnFinished -= OnSpawnFinished;
    }

    private void OnSpawnFinished()
    {
        _enemies.AddRange(GetComponentsInChildren<Enemy>());
        TransferEnemies(_enemies);
    }

    private void TransferEnemies(List<Enemy> enemies)
    {
        foreach (var enemy in enemies)
        {
            _gameVisior.AddEnemy(enemy);
        }
    }
}
