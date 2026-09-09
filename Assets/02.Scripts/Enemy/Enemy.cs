using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed = 1f;
    [SerializeField] protected float _health = 100;
    public int _damage = 40;
    private bool _isDead = false;

    [SerializeField] private Item[] _itemPrefabs;

    [SerializeField] private GameObject _deathEffectPrefab;

    [SerializeField] private AudioClip _hitSound;
    private AudioSource _audioSource;

    protected abstract void Move();

    private Animator _animator;

    public event Action OnDeath;
    // event: 구독할 수 있는 알림 통로
    // OnDeath를 이벤트로 선언, 외부에서는 이 메서드에 구독 또는 해제가 가능
    // 함수X, 키워드 O -> c#에서 특별한 의미를 갖도록 예약한 단어, 퍼랭이 글자 protected, private, void 등과 동격

    // Action: int, float 같은 타입명
    // -> 반환값이 없는 메서드가 들어감(대충 void라고 생각)

    //OnDeath: 이벤트 멤버 이름

    private void Awake()
    {
        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
        }

        _audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(float damage)
    {
        if (_isDead) return;

        _health -= damage;
        if (_animator != null)
        {
            _animator.SetTrigger("Hit");
        }

        if (_health <= 0)
        {
            Die();
            return;
        }

        _audioSource.PlayOneShot(_hitSound);
    }

    public void Die()
    {
        if (_isDead) return;
        _isDead = true;

        OnDeath?.Invoke();
        //Enemy 죽으면 -> 구독자한테 알림 보냄


        SpawnDeathEffect();
        SpawnItem();
        Destroy(gameObject);
    }

    private void SpawnDeathEffect()
    {
        Instantiate(_deathEffectPrefab, transform.position, Quaternion.identity);
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
        int randomIndex = UnityEngine.Random.Range(1, 11);

        if (randomIndex >= 1 && randomIndex <= 3)
        {
            int randomItem = UnityEngine.Random.Range(1, 4);
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