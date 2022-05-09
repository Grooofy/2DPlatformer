using UnityEngine;

[RequireComponent(typeof(Moving))]
public class Character : MonoBehaviour
{
    [SerializeField] private int _lifes;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForse;
    [SerializeField] private int _coinsNumber;

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

        if (_checker.IsEnemy)
            _moving.SpringOff();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _checker.IsGround)
            _moving.Jump(_jumpForse);
    }

    public void TakeDamage()
    {
        if (_lifes == 0)
            Destroy(gameObject);
        _moving.Discard();

        _lifes--;
    }

    public void AddCoin()
    {
        _coinsNumber++;
    }
}
