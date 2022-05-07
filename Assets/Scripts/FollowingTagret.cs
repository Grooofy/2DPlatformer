using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingTagret : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _offsetY = 2;

    private void Update() => transform.position = new Vector3(_target.position.x, _target.position.y + _offsetY, transform.position.z);
}
