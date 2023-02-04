using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DymanicButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    private bool _showed;

    private void Start()
    {

    }

    public void ShowedButton()
    {
        _showed = true;
    }

    private void Update()
    {
        if (_showed)
            _button.gameObject.SetActive(true);
        else
            _button.gameObject.SetActive(false);

        _showed = false;

    }

    private void LateUpdate()
    {
        _button.gameObject.transform.LookAt(new Vector3(transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z));
    }
}
