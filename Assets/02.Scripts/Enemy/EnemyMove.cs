using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}