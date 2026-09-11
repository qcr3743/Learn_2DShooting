using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

//space를 누를 때마다 총알을 생성 후 발사
//필요 속성
//- 총알 프리팹
//- 생성 취리
public class PlayerFire : MonoBehaviour
{
    [SerializeField] private float _fireInterval;
    private float _timer;
    private bool _isManualAttack = true;

    public GameObject BulletPrefab;
    public GameObject BulletSubPrefab;
    public Transform FirePoint1;
    public Transform FirePoint2;
    public Transform FirePointSub1;
    public Transform FirePointSub2;

    [SerializeField] private AudioClip _fireSound;
    private AudioSource _audioSource;

    private void Start()
    {
        _timer = _fireInterval;
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        AttackModeToggle();
        FireBullet();
    }

    private void AttackModeToggle()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _isManualAttack = !_isManualAttack;
        }
    }

    private void FireBullet()
    {
        if (_timer < _fireInterval)
        {
            return;
        }


        if (!_isManualAttack || (_isManualAttack && Input.GetKeyDown(KeyCode.Space)))
        {
            Fire();
        }
    }

    void Fire()
    {
        Bullet leftBullet = BulletPool.Instance.GetBullet();
        leftBullet.transform.position = FirePoint1.position;
        Bullet rightBullet = BulletPool.Instance.GetBullet();
        rightBullet.transform.position = FirePoint2.position;
        _audioSource.PlayOneShot(_fireSound);
        _timer = 0;
    }

    public void IncreaseFireRate(float _fireRateUpAmount)
    {
        _fireInterval = Mathf.Max(0.2f, _fireInterval - _fireRateUpAmount);
        Debug.Log($"발사 속도 증가!: {_fireInterval}");
    }
}