using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _sprite;
    private Coroutine _coroutine;

    private bool _isPlaying = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    public void PlayIdle() => _animator.SetTrigger("Idle");

    public void PlayWalk() => _animator.SetTrigger("Walk");

    public void LookAtForward(float direction)
    {
        if (Mathf.Approximately(direction, 0) == false)
            transform.localScale = new Vector3(Mathf.Sign(direction), 1, 1);
    }

    public void Blink()
    {
        if (_isPlaying)
            StopCoroutine(_coroutine);
        else
            _coroutine = StartCoroutine(DateBlink());
    }

    private IEnumerator DateBlink()
    {
        int number = 2;
        float timeAnimation = 0.3f;
        float timeCoroutine = 1;
        _sprite.DOFade(0, timeAnimation).SetLoops(number, LoopType.Yoyo);

        _isPlaying = true;
        yield return new WaitForSeconds(timeCoroutine);
        _isPlaying = false;
    }
}

