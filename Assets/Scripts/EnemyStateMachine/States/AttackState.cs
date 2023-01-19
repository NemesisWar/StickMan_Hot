using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] private float _delay;
    [SerializeField] private Bullets _bullet;
    [SerializeField] private Transform _shootpoint;
    private float _time;
    protected override IEnumerator Action(bool RunTime)
    {
        while (RunTime)
        {
            _time+=Time.deltaTime;
            if (_time >= _delay)
            {
                _time=0;
                Bullets bullet = Instantiate(_bullet, _shootpoint.position,_shootpoint.rotation);
                bullet.transform.LookAt(Player.transform.position);
                bullet.Init(Enemy.TimeShift);
            }

            yield return new WaitForEndOfFrame();
        }
    }

    protected override void AfterStopCoroutine()
    {
        Debug.Log("Spot");
    }
}
