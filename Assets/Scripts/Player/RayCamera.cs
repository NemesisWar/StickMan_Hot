using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCamera : MonoBehaviour
{
    private Camera _camera;
    private Ray _ray;
    [SerializeField]private float _distance;
    public Vector3 Target;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        _ray = _camera.ScreenPointToRay(new Vector3(_camera.pixelWidth / 2, _camera.scaledPixelHeight / 2, 0));
        if (Physics.Raycast(_ray, out RaycastHit hit, _distance))
        {
            if (hit.transform.gameObject != null)
            {
                Target = hit.point;
            }

            else
            {
                Target = Vector3.zero;
            }
        }
    }
}
