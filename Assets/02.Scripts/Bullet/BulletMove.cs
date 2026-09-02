using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed;
    private void Start()
    {
        
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(new Vector2(0f,1f) * speed * Time.deltaTime);
    }
}
