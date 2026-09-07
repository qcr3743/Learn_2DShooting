using UnityEngine;

public class ItemMoveToPlayer : MonoBehaviour
{
    public Transform player;
    [SerializeField] private float _moveSpeed = 3f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    private void Update()
    {
        Move();
    }

    void Move()
    {
        if (player == null) return;
        Vector2 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * _moveSpeed * Time.deltaTime);
    }
}