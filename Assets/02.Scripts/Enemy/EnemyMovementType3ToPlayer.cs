using UnityEngine;

public class EnemyMovementType3ToPlayer : Enemy

{
    public Transform player;
    private Vector3 _playerPos;

    protected override void Move()
    {
        if (player == null) return;
        _playerPos = player.position;
        Vector2 direction = (player.position - transform.position).normalized;
        float dx = direction.x;
        float dy = direction.y;
        // tan0 = dy /dx
        // tan^ * tan0 = tan^ * dy / dx
        // 0 = tant^ * dy / dx
        float seta = Mathf.Atan2(dy, dx);
        float angle = seta * Mathf.Rad2Deg + 90;
        //거의 공식

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
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