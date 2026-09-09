using UnityEngine;

public class Player : MonoBehaviour
{
    // 캡슐화
    // - 데이터 은닉
    // - 메서드를 통한 상태 변경
    [SerializeField] private int _hp = 100;
    [SerializeField] private GameObject _deathEffectPrefab;

    public int GetHp => _hp; //람다식 문법을 활용한 읽기 전용 프로퍼티(get을 간결하게 줄임)

    [SerializeField] private AudioClip _hitSound;
    [SerializeField] private AudioClip _deathSound;
    private AudioSource _audioSource;


    // 잘 설계된 클래스는
    // - 필드 (인스턴스 변수)
    // - 필드에 잘못된 값이 할당되지 않게 막고, 정상적으로 동작하는 메서드

    // getter/setter: 특정 데이터를 get/set 해주는 메서드
    // - set은 기술 지향 메서드지만, 우리는 도메인 지향을 추구해야함

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }


    public void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            Debug.LogWarning("데미지는 음수일 수 없습니다");
        }

        _hp -= damage;
        Debug.Log($"피격받았다! 플레이어의 HP: {_hp}");
        if (_hp <= 0)
        {
            SpawnDeathEffect();
            AudioSource.PlayClipAtPoint(_deathSound, Camera.main.transform.position);
            Destroy(gameObject);
        }

        _audioSource.PlayOneShot(_hitSound);
    }

    private void SpawnDeathEffect()
    {
        Instantiate(_deathEffectPrefab, transform.position, Quaternion.identity);
    }


    public void Heal(int _hpRecoveryAmount)
    {
        if (_hpRecoveryAmount < 0)
        {
            Debug.LogWarning("힐량은 음수일 수 없습니다");
        }

        _hp += _hpRecoveryAmount;
        Debug.Log($"회복! 플레이어의 HP: {_hp}");
    }
}