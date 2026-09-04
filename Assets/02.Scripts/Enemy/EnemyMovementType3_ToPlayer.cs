using UnityEngine;

public class EnemyMovementType3_ToPlayer : Enemy

{
    public Transform player;
    private Vector3 _playerPos;

    protected override void Move()
    {
        _playerPos = player.position;
        Vector2 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * _moveSpeed * Time.deltaTime);
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    private void Update()
    {
        Move();
    }
}