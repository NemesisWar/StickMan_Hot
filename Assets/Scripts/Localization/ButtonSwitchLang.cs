using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitchLang : MonoBehaviour
{
    public void OnButtonClick()
    {
        LocalizationInstaller.Instance.CurrentLanguage = name;
    }
}
