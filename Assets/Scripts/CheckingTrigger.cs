using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class CheckingTrigger : MonoBehaviour
{
    public bool IsGround => _isGround;
    public bool IsEnemy => _isEnemy;

    private BoxCollider2D _boxCollider2D;
    private Rigidbody2D _rigidbody2D;

    private bool _isGround = false;
    private bool _isEnemy = false;
    
    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _boxCollider2D.isTrigger = true;
        _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            _isEnemy = true;
            enemy.TakeDamage();
        }
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            coin.PickUp();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
            _isGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isGround = false;
        _isEnemy = false;
    }
}
