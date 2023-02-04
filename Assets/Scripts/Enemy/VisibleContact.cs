using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class VisibleContact : MonoBehaviour
{
    public bool PlayerVisible { get; private set; }
    [SerializeField] private Enemy _enemy;
    private Player _player;
    private Coroutine _coroutine;
    [SerializeField] private float _rayDistance;
    [SerializeField] private GameObject _locator;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _player = _enemy.Player;
    }

    private void OnEnable()
    {
        _enemy.CanMove += OnCanMove;
    }

    private void OnDisable()
    {
        _enemy.CanMove -= OnCanMove;
    }

    private void OnCanMove(bool timeTun)
    {
        if(timeTun == true)
        {
            _coroutine = StartCoroutine(TrySee(timeTun));
        }

        else
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator TrySee(bool timeRun)
    {
        while (timeRun)
        {
            _locator.transform.LookAt(_player.transform.position);
            Debug.DrawRay(_locator.transform.position, _locator.transform.forward*_rayDistance, Color.blue);
            Ray ray = new Ray(_locator.transform.position, _locator.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, _rayDistance))
            {
                if (hit.transform.gameObject.GetComponent<Player>())
                {
                    PlayerVisible = true;
                }
                else
                {
                    PlayerVisible = false;
                }
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
