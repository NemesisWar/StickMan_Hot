using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private int _currentLevel;
    [SerializeField] private GameProgress _progress;

    private void Start()
    {
        _currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (_progress == null)
        {
            _progress = GetComponent<GameProgress>();
        }
        if(_currentLevel == 0)
        {
            _progress.Load();
        }
    }

    public void ChangeLevel()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        _progress.Save(_currentLevel+1);
#endif
        SceneManager.LoadScene(_currentLevel+1);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(_currentLevel);
    }

    public void LoadSavedScene(int level)
    {
        SceneManager.LoadScene(level);
    }

}
