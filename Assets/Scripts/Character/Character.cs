using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Moving))]
public class Character : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForse;
    private CheckingTrigger _checker;

    private float _direction;
    private Moving _moving;

    private void Start()
    {
        _moving = GetComponent<Moving>();
        _checker = GetComponentInChildren<CheckingTrigger>();
    }

    private void FixedUpdate()
    {
        _direction = Input.GetAxis("Horizontal");
        _moving.Move(_direction, _speed);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _checker.IsGround)
            _moving.Jump(_jumpForse);

        if (_checker.IsEnemy)
        {
            _moving.SpringOff();
        }
    }
}
