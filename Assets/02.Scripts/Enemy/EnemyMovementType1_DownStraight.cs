using System;
using UnityEngine;

public class EnemyMovementType1_DownStraight : Enemy
{
    public EnemyMovementType1_DownStraight(float moveSpeed, float health)
    {
        this.moveSpeed = moveSpeed;
        this.health = health;
    }

    public override void Move()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }

    private void Update()
    {
        Move();
    }
}