using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPoint : MonoBehaviour
{
    [SerializeField] private RayCamera _rayCamera;

    private void Update()
    {
        if(_rayCamera.Target!=Vector3.zero)
        {
            transform.LookAt(_rayCamera.Target);
        }
    }
}
