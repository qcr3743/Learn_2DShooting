using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed = 1f;
    [SerializeField] protected float _health = 100;
    public int _damage = 40;
    private bool _isDead = false;

    [SerializeField] private ItemSpawnDataTableSO _itemSpawnDataTable;

    [SerializeField] private GameObject _deathEffectPrefab;

    [SerializeField] private AudioClip _hitSound;
    private AudioSource _audioSource;

    protected abstract void Move();

    private Animator _animator;

    public static event Action OnDeath;
    // event: 키워드 
    // 키워드: c#에서 특별한 의미를 갖도록 예약한 단어, 퍼랭이 글자 protected, private, void 등과 동격
    // OnDeath라는 멤버를 이벤트로 선언
    // 외부 객체는 이 이벤트에 자신의 메서드를 구독하거나 구독해제만 할 수 있음

    // Action: int, float 같은 타입명이라고 생각하면 비슷함
    // -> 멀티캐스트 델리게이트 타입
    // -> 반환값이 없는 메소드를 저장 가능

    // OnDeath: 이벤트 멤버 이름
    // 이벤트에 구독된 메서드들의 참조가 연결되어있음
    // [ KillCounter 객체 + AddKillCount 메서드 ]

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
        //OnDeath가 null이 아닐 때만 뒤의 Invoke를 실행

        // 싱글톤 패턴
        // 1. 전역적으로 접근 가능하다
        // 2. 인스턴스(생성된 객체)가 하나임을 보장한다
        //ScoreManager.Instance.AddScore(1); 
        //이런식으로 전역에서 접근 가능한 인스턴스를 생성해서 바로 함수 사용 가능
        //여러개가 있는 경우 랜덤한 객체에 접근함. 그러니까 하나임을 보장할 수 있을 때만 할 것

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
        int totalWeight = 0;
        foreach (ItemSpawnData data in _itemSpawnDataTable.Datas)
        {
            totalWeight += data.Weight;
        }

        int randomWeight = UnityEngine.Random.Range(0, totalWeight);

        int cumulativeWeight = 0;

        foreach (ItemSpawnData data in _itemSpawnDataTable.Datas)
        {
            cumulativeWeight += data.Weight;
            if (randomWeight < cumulativeWeight)
            {
                GameObject item = Instantiate(data.ItemPrefab);
                item.transform.position = transform.position;
                break;
            }
        }
    }
}