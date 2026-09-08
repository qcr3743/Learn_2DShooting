using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 3f;
    private float _timer = 0f;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.Die();
        }
    }
}