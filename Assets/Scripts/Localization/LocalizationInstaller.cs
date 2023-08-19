using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.Events;

public class LocalizationInstaller : MonoBehaviour
{
    [DllImport("_Internal")] private static extern string GetLang();
    private string _currentLanguage;
    public string CurrentLanguage 
    {  get 
        {
            return _currentLanguage; 
        }
        set
        {
           _currentLanguage = value;
            OnLanguageChange?.Invoke(_currentLanguage);
        }
    }
    public event UnityAction <string> OnLanguageChange;

    public static LocalizationInstaller Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
#if !UNITY_EDITOR && UNITY_WEBGL
            _currentLanguage = GetLang();
#endif
#if UNITY_EDITOR
            _currentLanguage = "ru";
#endif
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
