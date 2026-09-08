using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed = 1f;
    [SerializeField] protected float _health = 100;
    public int _damage = 40;

    [SerializeField] private Item[] _itemPrefabs;
    protected abstract void Move();

    private Animator _animator;

    private void Awake()
    {
        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
        }
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_animator != null)
        {
            _animator.SetTrigger("Hit");
        }

        if (_health <= 0)
        {
            SpawnItem();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        Player player = other.gameObject.GetComponent<Player>();
        player.TakeDamage(_damage);

        Destroy(gameObject);
    }

    void SpawnItem()
    {
        int randomIndex = Random.Range(1, 11);

        if (randomIndex >= 1 && randomIndex <= 3)
        {
            int randomItem = Random.Range(1, 4);
            if (randomItem == 1)
            {
                Debug.Log($"Hp회복 아이템 생성 ID: {GetInstanceID()}");
                Item item = Instantiate(_itemPrefabs[0]);
                item.transform.position = transform.position;
            }
            else if (randomItem == 2)
            {
                Debug.Log($"이동속도 상승 아이템 생성 ID: {GetInstanceID()}");
                Item item = Instantiate(_itemPrefabs[1]);
                item.transform.position = transform.position;
            }
            else
            {
                Debug.Log($"발사속도 상승 아이템 생성 ID: {GetInstanceID()}");
                Item item = Instantiate(_itemPrefabs[2]);
                item.transform.position = transform.position;
            }
        }
    }
}