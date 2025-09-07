using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;

    private Rigidbody2D _rigidbody;
    private float _maxRotation = 45f;
    private float _minRotation = -45f;
    private float _rotaionSpeed = -50f;
    private float _halfCircule = 360f;
    private int _jumpForce = 300;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_sprite.transform.rotation.z >= _minRotation / _halfCircule)
        {
            _sprite.transform.Rotate(0, 0, _rotaionSpeed * Time.deltaTime);
        }
    }

    public void Jump()
    {
        _rigidbody.AddForce(new Vector2(0, _jumpForce));
        _sprite.transform.rotation = Quaternion.Euler(0, 0, _maxRotation);
    }
}