using UnityEngine;
using UnityEngine.UI;

//space를 누를 때마다 총알을 생성 후 발사
//필요 속성
//- 총알 프리팹
//- 생성 취리
public class PlayerFire : MonoBehaviour
{
    private bool CanFire = true;
    public float TimerTime;
    private float time;
    private bool IsManualAttack = true;
    
    public GameObject BulletPrefab;
    public GameObject BulletSubPrefab;
    public Transform FirePoint1;
    public Transform FirePoint2;
    public Transform FirePointSub1;
    public Transform FirePointSub2;

    private void Start()
    {
        time = TimerTime;
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
            IsManualAttack = !IsManualAttack;
        }
    } 

    private void FireBullet()
    {
        if (CanFire &&(!IsManualAttack || (IsManualAttack && Input.GetKeyDown(KeyCode.Space))))
        {
            Fire();
        }
        
        TimerTime -= Time.deltaTime;
        if (TimerTime <= 0)
        {
            CanFire = true;
        }
        
    }

    void Fire()
    {
        Instantiate(BulletPrefab, FirePoint1.position, FirePoint1.rotation);
        Instantiate(BulletPrefab, FirePoint2.position, FirePoint2.rotation);
        Instantiate(BulletSubPrefab, FirePointSub1.position, FirePointSub1.rotation);
        Instantiate(BulletSubPrefab, FirePointSub2.position, FirePointSub2.rotation);
        CanFire = false;
        TimerTime = time;
    }
}