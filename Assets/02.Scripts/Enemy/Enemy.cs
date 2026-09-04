using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed = 1f;
    [SerializeField] protected float _health = 100;
    public int _damage = 40;
    protected abstract void Move();

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}