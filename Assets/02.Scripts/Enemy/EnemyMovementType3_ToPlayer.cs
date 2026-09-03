using UnityEngine;

public class EnemyMovementType3_ToPlayer : Enemy

{
    public Transform player;
    private Vector2 _playerPos;

    public EnemyMovementType3_ToPlayer(float _moveSpeed, float _health)
    {
        this._moveSpeed = _moveSpeed;
        this._health = _health;
    }

    protected override void Move()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * _moveSpeed * Time.deltaTime);
    }

    private void Update()
    {
        Move();
    }
}