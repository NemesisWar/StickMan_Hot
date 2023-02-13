using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class PlayerMove : PlayerControl
{
    private AudioSource _audioSource;
    public event UnityAction<bool> IsMove;
    private Vector3 _moveDirection;
    [SerializeField] private float _defaultSpeed;


    protected override void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _playerInput.Player.Move.started += cxt => StartMove();
        _playerInput.Player.Move.canceled += cxt => StopMove();
    }

    protected override void AfterAwake()
    {
    }

    protected override void AfterEnable()
    {
    }

    protected override void AfterDisable()
    {
    }

    private void Update()
    {
        _playerInput.Player.Move.performed += cxt => OnMove();
        Move(OnMove());
    }

    private Vector3 OnMove()
    {
        _moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();
        return new Vector3(_moveDirection.x, 0, _moveDirection.y);
    }


    private void Move(Vector3 direction)
    {
        Vector3 moved = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * direction;
        transform.position += moved * _defaultSpeed * Time.deltaTime;
    }

    private void StopMove()
    {
        _audioSource.Stop();
        IsMove?.Invoke(false);
    }

    private void StartMove()
    {
        _audioSource.Play();
        IsMove?.Invoke(true);
    }

}
