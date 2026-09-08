using UnityEngine;

public class EnemyMovementType2ToPlayerInitialPoint : Enemy
{
    public Transform player;
    private Vector3 _playerInitialPos;
    private Vector3 _enemyInitialPos;

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

    protected override void Move()
    {
        if (player == null) return;

        Vector2 direction = (_playerInitialPos - _enemyInitialPos).normalized;
        float dx = direction.x;
        float dy = direction.y;
        //tanθ = dy / dx
        // tan⁻¹(tanθ) = tan⁻¹(dy / dx)
        //θ = tan⁻¹(dy / dx)
        float seta = Mathf.Atan2(dy, dx);
        float angle = seta * Mathf.Rad2Deg + 90;
        //거의 공식

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        transform.Translate(direction * _moveSpeed * Time.deltaTime);
    }
}