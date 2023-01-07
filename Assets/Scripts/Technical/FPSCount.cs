using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCount : MonoBehaviour
{
    private float _fps;
    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
    }

    void OnGUI()
    {
        _fps = 1.0f / Time.deltaTime;
        GUILayout.Label("FPS: " + (int)_fps);
    }
}
