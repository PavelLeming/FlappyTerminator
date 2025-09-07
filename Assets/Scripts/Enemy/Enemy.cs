using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PoolableObject
{
    [SerializeField] private BulletsSpawnPoint _bulletSpawnPoint;

    private  EnemyBulletSpawner _bulletSpawner;
    private float _xPositionForRealise = -4f;
    private int _timeForShot = 3;
    private Rigidbody2D _rigidbody;
    public event Action<Enemy> ReadyForRelease;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(TimeUp());
    }

    private void Update()
    {
        if (transform.position.x <= _xPositionForRealise)
        {
            ReadyForRelease?.Invoke(this);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>())
        {
            ReadyForRelease?.Invoke(this);
        }
    }

    public void Initialize(float speed, float xPosition, float yPosition, EnemyBulletSpawner bulletSpawner)
    {
        _rigidbody.velocity = new Vector3(speed, 0, 0);
        transform.position = new Vector3(xPosition, yPosition, 0);
        _bulletSpawner = bulletSpawner;
    }

    private IEnumerator TimeUp()
    {
        var wait = new WaitForSeconds(_timeForShot);

        while (enabled)
        {
            yield return wait;
            Bullet bullet = _bulletSpawner.SpawnBullet();
            bullet.transform.position = _bulletSpawnPoint.transform.position;
        }
    }
}
