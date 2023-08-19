using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

[System.Serializable]
public class ProgressInfo
{
    [HideInInspector]public int Level;
}

public class GameProgress : MonoBehaviour
{
    [SerializeField] private SceneChanger _sceneChanger;
    [DllImport("__Internal")] private static extern void SaveExternal(string date);
    [DllImport("__Internal")] private static extern void LoadExternal();
    [DllImport("__Internal")] private static extern void ShowAdversting();
    public ProgressInfo ProgressInfo;

    private void Start()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        PauseGame();
        ShowAdversting();        
#endif
    }

    public void Save(int level)
    {
        ProgressInfo.Level = level;
        string jsonString = JsonUtility.ToJson(ProgressInfo);
        SaveExternal(jsonString);
    }

    public void LoadPlayerInfo(string data)
    {
        ProgressInfo = JsonUtility.FromJson<ProgressInfo>(data);
        Debug.Log("UnityLoad"+ProgressInfo.Level);
    }

    public void Load()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        LoadExternal();
#endif
    }

    public void LoadSavedGame()
    {
        if (ProgressInfo.Level == 0)
            StartNewGame();
        _sceneChanger.LoadSavedScene(ProgressInfo.Level);
    }

    public void StartNewGame()
    {
        ProgressInfo.Level = 1;
        _sceneChanger.LoadSavedScene(ProgressInfo.Level);
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
