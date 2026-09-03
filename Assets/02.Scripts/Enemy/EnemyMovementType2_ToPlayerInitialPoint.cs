using UnityEngine;

public class EnemyMovementType3_ToPlayerInitialPoint : Enemy
{
    public Transform player;
    private Vector3 _playerInitialPos;

    public EnemyMovementType3_ToPlayerInitialPoint(float moveSpeed, float health)
    {
        this.moveSpeed = moveSpeed;
        this.health = health;
    }

    public override void Move()
    {
        Vector2 direction = (_playerInitialPos - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    private void Start()
    {
        _playerInitialPos = player.position;
    }

    private void Update()
    {
        Move();
    }
}