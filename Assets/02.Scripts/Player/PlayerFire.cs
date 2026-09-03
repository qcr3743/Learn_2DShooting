using UnityEngine;
using UnityEngine.UI;

//space를 누를 때마다 총알을 생성 후 발사
//필요 속성
//- 총알 프리팹
//- 생성 취리
public class PlayerFire : MonoBehaviour
{
    private bool _canFire = true;
    public float timerTime;
    private float _time;
    private bool _isManualAttack = true;

    public GameObject BulletPrefab;
    public GameObject BulletSubPrefab;
    public Transform FirePoint1;
    public Transform FirePoint2;
    public Transform FirePointSub1;
    public Transform FirePointSub2;

    private void Start()
    {
        _time = timerTime;
    }

    private void Update()
    {
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
        if (_canFire && (!_isManualAttack || (_isManualAttack && Input.GetKeyDown(KeyCode.Space))))
        {
            Fire();
        }

        timerTime -= UnityEngine.Time.deltaTime;
        if (timerTime <= 0)
        {
            _canFire = true;
        }
    }

    void Fire()
    {
        Instantiate(BulletPrefab, FirePoint1.position, FirePoint1.rotation);
        Instantiate(BulletPrefab, FirePoint2.position, FirePoint2.rotation);
        Instantiate(BulletSubPrefab, FirePointSub1.position, FirePointSub1.rotation);
        Instantiate(BulletSubPrefab, FirePointSub2.position, FirePointSub2.rotation);
        _canFire = false;
        timerTime = _time;
    }
}