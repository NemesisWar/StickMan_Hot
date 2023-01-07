using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transictions : MonoBehaviour
{
    public State TargetState => _targetState;
    [SerializeField] private State _targetState;
    protected Player Player;
    public bool NeedTransit { get; protected set; }

    public void Init(Player player)
    {
       Player = player;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
