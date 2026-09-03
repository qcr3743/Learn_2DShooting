using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public float health = 100;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }
}