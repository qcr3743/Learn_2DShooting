using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] protected GameObject _itemGetEffect;

    private void Awake()
    {
        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        ApplyEffect(other.gameObject);

        SpawnItemGetEffect();

        Destroy(gameObject);
    }

    protected void SpawnItemGetEffect()
    {
        Instantiate(_itemGetEffect, transform.position, Quaternion.identity);
    }

    protected abstract void ApplyEffect(GameObject player);
}