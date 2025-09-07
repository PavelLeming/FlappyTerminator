using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawner : Spawner<Bullet>
{
    private float _speed = -1.5f;

    protected override void GetAction(Bullet bullet)
    {
        PooledObjects.Add(bullet);
        bullet.gameObject.SetActive(true);
        bullet.Rigidbody.velocity = new Vector3(_speed, 0, 0);
        bullet.ReadyForRelease += Release;
    }

    protected override void Release(Bullet bullet)
    {
        PooledObjects.Remove(bullet);
        bullet.ReadyForRelease -= Release;
        Objects.Release(bullet);
    }

    public Bullet SpawnBullet()
    {
        return Objects.Get();
    }
}
