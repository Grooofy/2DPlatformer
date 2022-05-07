using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _life;

    private Moving _moving;

    private Dictionary<string , int> _states = new Dictionary<string, int>()
    {
        { "Idle", 0 },
        { "WalkLeft", -1 },
        { "WalkRight", 1 }
    };
    private float _direction;
    private int _delay = 4;

    private void Start()
    {
        _moving = GetComponent<Moving>();
        StartCoroutine(FadeState());
    }

    private void FixedUpdate()
    {
        _moving.Move(_direction, _speed);
    }

    public void TakeDamage()
    {
        if (_life == 0)
            Destroy(gameObject);

        _life--;
    }

    private IEnumerator FadeState()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_delay);

        while (true)
        {
            foreach (var state in _states)
            {
                _direction = state.Value;
                yield return waitForSeconds;
            }
        }
    }
}

