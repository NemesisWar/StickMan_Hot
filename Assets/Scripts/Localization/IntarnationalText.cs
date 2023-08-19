using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntarnationalText : MonoBehaviour
{
    [SerializeField] private string _ru;
    [SerializeField] private string _en;
    [SerializeField] private string _tr;
    private TMP_Text _text;


    private void OnEnable()
    {
        LocalizationInstaller.Instance.OnLanguageChange += OnChangeLanguage;
    }

    private void OnDisable()
    {
        LocalizationInstaller.Instance.OnLanguageChange -= OnChangeLanguage;
    }

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        OnChangeLanguage(LocalizationInstaller.Instance.CurrentLanguage);
    }

    private void OnChangeLanguage(string lang)
    {
        if (lang != null)
        {
            if (lang == "ru" ||lang == "uk" || lang == "be")
            {
                _text.text = _ru;
            }
            else if (lang == "tr")
            {
                _text.text = _tr;
            }
            else
            {
                _text.text = _en;
            }
        }
        else
        {
            _text.text = _en;
        }
    }

}
