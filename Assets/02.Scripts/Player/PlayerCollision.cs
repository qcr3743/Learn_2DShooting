using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private int _hp = 100;

    private void Start()
    {
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            _hp -= enemy._damage;
            Destroy(other.gameObject);
            if (_hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}