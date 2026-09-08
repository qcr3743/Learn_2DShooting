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

    private void Start()
    {
        _timer = _fireInterval;
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
        Instantiate(BulletPrefab, FirePoint1.position, FirePoint1.rotation);
        Instantiate(BulletPrefab, FirePoint2.position, FirePoint2.rotation);
        Instantiate(BulletSubPrefab, FirePointSub1.position, FirePointSub1.rotation);
        Instantiate(BulletSubPrefab, FirePointSub2.position, FirePointSub2.rotation);
        _timer = 0;
    }

    public void IncreaseFireRate(float _fireRateUpAmount)
    {
        _fireInterval = Mathf.Max(0.2f, _fireInterval - _fireRateUpAmount);
        Debug.Log($"발사 속도 증가!: {_fireInterval}");
    }
}