using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerBulletSpawner _bulletSpawner;

    private Rigidbody2D _rigidbody;
    public event Action GameOver;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_inputReader.GetIsJump())
        {
            _mover.Jump();
        }

        if (_inputReader.GetIsAttack())
        {
            _bulletSpawner.SpawnBullet();
        }
    }

    private void OnCollisionEnter2D()
    {
        GameOver?.Invoke();
    }

    public void Reset()
    {
        transform.position = Vector3.zero;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = 0;
    }
}
