using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemiesCounter : MonoBehaviour
{
    [SerializeField] private GameVisitor _gameVisitor;
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        _gameVisitor.CountEnemies += DrawCount;
    }

    private void OnDisable()
    {
        _gameVisitor.CountEnemies -= DrawCount;
    }

    private void DrawCount(int count)
    {
        _text.text = count.ToString();
    }
}
