using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private EnemyBulletSpawner _bulletSpawner;

    private float _speed = -0.5f;
    private float _xPosition = 4f;
    private float _minYPostion = -3f;
    private float _maxYposition = 4f;
    private float _spawnTimer = 3f;

    protected override void GetAction(Enemy enemy)
    {
        PooledObjects.Add(enemy);
        enemy.gameObject.SetActive(true);
        enemy.Initialize(_speed, _xPosition, Random.Range(_minYPostion, _maxYposition), _bulletSpawner);
        enemy.ReadyForRelease += Release;
    }

    protected override void Release(Enemy enemy)
    {
        PooledObjects.Remove(enemy);
        enemy.ReadyForRelease -= Release;
        Objects.Release(enemy);
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var wait = new WaitForSeconds(_spawnTimer);

        while (enabled)
        {
            Objects.Get();


            yield return wait;
        }
    }
}
