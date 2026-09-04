using UnityEngine;

public class EnemyMovementType3_ToPlayerInitialPoint : Enemy
{
    public Transform player;
    private Vector3 _playerInitialPos;
    private Vector3 _enemyInitialPos;

    protected override void Move()
    {
        Vector2 direction = (_playerInitialPos - _enemyInitialPos).normalized;
        transform.Translate(direction * _moveSpeed * Time.deltaTime);
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _playerInitialPos = player.position;
        _enemyInitialPos = transform.position;
    }

    private void Update()
    {
        Move();
    }
}