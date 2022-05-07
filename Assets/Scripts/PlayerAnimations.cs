using UnityEngine;


[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;

    private void Start() => _animator = GetComponent<Animator>();
    
    public void PlayIdle() => _animator.SetTrigger("Idle");

    public void PlayWalk() =>_animator.SetTrigger("Walk");

    public void LookAtForward(float direction)
    {
        if (Mathf.Approximately(direction, 0) == false)
            transform.localScale = new Vector3(Mathf.Sign(direction), 1, 1);
        
    }
}
   
