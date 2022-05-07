using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Moving : MonoBehaviour
{
    private PlayerAnimations _animation;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animation = GetComponentInChildren<PlayerAnimations>();
    } 

    public void Move(float direction, float speed)
    {
        if (Mathf.Approximately(direction, 0))
            _animation.PlayIdle();
        else
            _animation.PlayWalk();

        _animation.LookAtForward(direction);

        _rigidbody2D.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, _rigidbody2D.velocity.y);
    }

    public void Jump(float jumpForse) => _rigidbody2D.AddForce(Vector2.up * jumpForse, ForceMode2D.Impulse);

    public void SpringOff()
    {
        float forseImpulse = 2;
        _rigidbody2D.AddForce(Vector2.up * forseImpulse, ForceMode2D.Impulse);
    }
}
