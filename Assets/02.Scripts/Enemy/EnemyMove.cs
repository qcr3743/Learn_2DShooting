using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float moveSpeed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }
}