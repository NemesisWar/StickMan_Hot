using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private int _currentLevel;

    public void ChangeLevel()
    {
        SceneManager.LoadScene(_currentLevel+1);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(_currentLevel);
    }

}
