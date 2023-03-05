using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameVisitor : MonoBehaviour
{
    public event UnityAction<int> CountEnemies;
    public event UnityAction<bool> PlayerWin;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _enemyContainer;
    [SerializeField] private int _enemyCount;

    private void OnEnable()
    {
        Cursor.visible = false;
        _player.Die += OnPlayerDie;
    }

    private void OnDisable()
    {
        _player.Die -= OnPlayerDie;
    }

    public void AddEnemy(Enemy enemy)
    {
        enemy.Die += RemoveEmeny;
        _enemyCount++;
        CountEnemies?.Invoke(_enemyCount);
    }

    private void RemoveEmeny(Enemy enemy)
    {
        enemy.Die -= RemoveEmeny;
        _enemyCount--;
        CountEnemies?.Invoke(_enemyCount);
        if(_enemyCount == 0)
        {
            PlayerWin?.Invoke(true);
            Cursor.visible = true;
        }
    } 

    private void OnPlayerDie()
    {
        PlayerWin?.Invoke(false);
        Cursor.visible = true;
    }
}
