using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidBody;
    private bool _isLanded;
    private int _coinsCount;

    public event UnityAction<int> CoinPicked;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidBody.velocity = new Vector2(_speed, _rigidBody.velocity.y);

        if (Input.GetButtonDown("Fire1") && _isLanded)
        {
            _rigidBody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isLanded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isLanded = false;
    }

    public void AddCoin()
    {
        _coinsCount++;
        CoinPicked?.Invoke(_coinsCount);
    }
}
