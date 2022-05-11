using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _life;
    [SerializeField] private int _delay = 5;

    private Moving _moving;
    private Dictionary<string, int> _states = new Dictionary<string, int>()
    {
        { "Idle", 0 },
        { "WalkLeft", -1 },
        { "WalkRight", 1 }
    };
    private float _direction;
    

    private void Start()
    {
        _moving = GetComponent<Moving>();
        StartCoroutine(FadeState());
    }

    private void FixedUpdate()
    {
        _moving.Move(_direction, _speed);
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

    public void TakeDamage()
    {
        if (_life == 0)
            Die();

        _life--;
    }

    private void Die()
    {
        StartCoroutine(DateDie());
    }

    private IEnumerator DateDie()
    {
        float time = 0.4f;

        transform.DOScale(0, time);

        yield return new WaitForSeconds(time + 0.1f);

        Destroy(gameObject);
    }
}

