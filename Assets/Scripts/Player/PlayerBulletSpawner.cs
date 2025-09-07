using UnityEngine;

public class PlayerBulletSpawner : Spawner<Bullet>
{
    [SerializeField] private BulletsSpawnPoint _spawnPoint;
    [SerializeField] private Player _player;

    private int _double = 2;

    protected override void GetAction(Bullet bullet)
    {
        PooledObjects.Add(bullet);
        bullet.transform.position = _spawnPoint.transform.position;
        bullet.gameObject.SetActive(true);
        bullet.transform.rotation = _player.transform.rotation;
        bullet.Rigidbody.velocity = new Vector3(1 - bullet.transform.rotation.z * _double, bullet.transform.rotation.z * _double, 0);
        bullet.ReadyForRelease += Release;
    }

    protected override void Release(Bullet bullet)
    {
        PooledObjects.Remove(bullet);
        bullet.ReadyForRelease -= Release;
        Objects.Release(bullet);
    }

    public void SpawnBullet()
    {
        Objects.Get();
    }
}
