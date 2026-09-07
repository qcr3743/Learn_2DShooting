using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private void Start()
    {
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        ApplyEffect(other.gameObject);

        Destroy(gameObject);
    }

    protected abstract void ApplyEffect(GameObject player);
}