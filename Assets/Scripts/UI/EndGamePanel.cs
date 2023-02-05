using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGamePanel : MonoBehaviour
{
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private GameObject LoosePanel;
    [SerializeField] private GameVisitor _gameVisior;

    private void OnEnable()
    {
        _gameVisior.PlayerWin += ShowEndGameBar;
    }

    private void OnDisable()
    {
        _gameVisior.PlayerWin -= ShowEndGameBar;
    }

    private void ShowEndGameBar(bool playerWin)
    {
        if (playerWin)
        {
            WinPanel.SetActive(true);
        }
        else
        {
            LoosePanel.SetActive(true);
        }
    }
}
