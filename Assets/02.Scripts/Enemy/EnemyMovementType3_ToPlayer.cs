using UnityEngine;

public class EnemyMovementType3_ToPlayer : Enemy

{
    public Transform player;
    private Vector2 _playerPos;

    public EnemyMovementType3_ToPlayer(float moveSpeed, float health)
    {
        this.moveSpeed = moveSpeed;
        this.health = health;
    }

    public override void Move()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    private void Update()
    {
        Move();
    }
}