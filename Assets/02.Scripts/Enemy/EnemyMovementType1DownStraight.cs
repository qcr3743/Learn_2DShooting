using System;
using UnityEngine;

public class EnemyMovementType1DownStraight : Enemy
{
    protected override void Move()
    {
        transform.Translate(Vector3.down * _moveSpeed * Time.deltaTime);
    }

    private void Update()
    {
        Move();
    }
}