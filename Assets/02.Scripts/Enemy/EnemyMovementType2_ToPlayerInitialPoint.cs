using UnityEngine;

public class EnemyMovementType3_ToPlayerInitialPoint : Enemy
{
    public Transform player;
    private Vector3 _playerInitialPos;
    private Vector3 _enemyInitialPos;

    public EnemyMovementType3_ToPlayerInitialPoint(float _moveSpeed, float _health)
    {
        this._moveSpeed = _moveSpeed;
        this._health = _health;
    }

    protected override void Move()
    {
        Vector2 direction = (_playerInitialPos - _enemyInitialPos).normalized;
        transform.Translate(direction * _moveSpeed * Time.deltaTime);
    }

    private void Start()
    {
        _playerInitialPos = player.position;
        _enemyInitialPos = transform.position;
    }

    private void Update()
    {
        Move();
    }
}