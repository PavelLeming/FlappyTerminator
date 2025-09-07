using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletSpawner : Spawner<Bullet>
{
    [SerializeField] private BulletsSpawnPoint _spawnPoint;

    protected override void ActionOnGet(Bullet bullet)
    {
        PooledObjects.Add(bullet);
        bullet.transform.position = _spawnPoint.transform.position;
        bullet.gameObject.SetActive(true);
        bullet.Rigidbody.velocity = new Vector3(1, 0, 0);
        bullet.ReadyForRelease += Release;
    }

    protected override void Release(Bullet bullet)
    {
        PooledObjects.Remove(bullet);
        bullet.ReadyForRelease -= Release;
        _objects.Release(bullet);
    }

    public void SpawnBullet()
    {
        _objects.Get();
    }
}
