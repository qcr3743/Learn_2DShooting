using UnityEngine;
//space를 누를 때마다 총알을 생성 후 발사
//필요 속성
//- 총알 프리팹
//- 생성 취리
public class PlayerFire : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform FirePoint1;
    public Transform FirePoint2;
    private void Start()
    {
        
    }

    private void Update()
    {
        //1. 스페이스바 누름
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //2. 총알 프리팹 생성
            //Instantiate는 프리팹을 복사해서 게임 오브젝트를 생성하고 씬에 넣어주는 기능
            Instantiate(BulletPrefab, FirePoint1.position, FirePoint1.rotation);
            Instantiate(BulletPrefab, FirePoint2.position, FirePoint2.rotation);
        }
    }
}
