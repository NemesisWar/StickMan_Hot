using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
    [SerializeField] private int _limitFRS;
    [SerializeField] private int _vSincValue;
    private void Awake()
    {
        Application.targetFrameRate = _limitFRS;
        QualitySettings.vSyncCount = _vSincValue;
    }
}
