using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction Die;

    public void TakeDamage()
    {
        Die?.Invoke();
        GameObject DeadPlayer = new GameObject("DeadPlayer");
        DeadPlayer.transform.position = transform.position;
        DeadPlayer.AddComponent<Camera>();
        Destroy(this.gameObject);
    }
}
