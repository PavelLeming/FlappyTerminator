using UnityEngine;

public class Bullet : PoolableObject
{
    private float _minXPosition = -4f;
    private float _maxXPosition = 4f;
    public event System.Action<Bullet> ReadyForRelease;

    public Rigidbody2D Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (transform.position.x < _minXPosition || transform.position.x > _maxXPosition)
        {
            ReadyForRelease?.Invoke(this);
        }
    }
}
