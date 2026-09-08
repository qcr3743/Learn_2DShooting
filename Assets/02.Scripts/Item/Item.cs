using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private Animator _animator;

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

        Destroy(gameObject);
    }

    protected abstract void ApplyEffect(GameObject player);
}