using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : PoolableObject
{
    public event System.Action<Bullet> ReadyForRelease;

    public Rigidbody2D Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Wall>())
        {
            ReadyForRelease?.Invoke(this);
        }
    }
}
