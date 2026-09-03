using System;
using UnityEngine;

public class EnemyMovementType1_DownStraight : Enemy
{
    public EnemyMovementType1_DownStraight(float _moveSpeed, float _health)
    {
        this._moveSpeed = _moveSpeed;
        this._health = _health;
    }

    protected override void Move()
    {
        transform.Translate(Vector3.down * _moveSpeed * Time.deltaTime);
    }

    private void Update()
    {
        Move();
    }
}