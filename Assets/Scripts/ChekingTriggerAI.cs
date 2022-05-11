using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChekingTriggerAI : MonoBehaviour
{
    public bool IsCharacter => _isCharacter;

    private BoxCollider2D _boxCollider2D;
    private Rigidbody2D _rigidbody2D;

    private bool _isCharacter = false;

    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _boxCollider2D.isTrigger = true;
        _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Character character))
        {
            _isCharacter = true;
            character.TakeDamage();
           
        }
    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        _isCharacter = false;
    }
}
