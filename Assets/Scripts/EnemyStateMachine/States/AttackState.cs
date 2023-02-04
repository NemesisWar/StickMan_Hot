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
        Animator.SetBool("Walk", false);
        Animator.SetBool("ReadyToShoot", true);
        Animator.speed = 1;
        while (RunTime)
        {
            _time+=Time.deltaTime;
            transform.LookAt(Player.transform.position);
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
        Animator.speed = 0;
    }
}
