using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private static BulletPool _instance = null;
    public static BulletPool Instance => _instance;


    // 오브젝트 풀링: 오브젝트의 Pool(웅덩이, 창고)를 만듬
    // -> 그 안에 기임 오브젝트를 미리 만듬
    // -> 필요할 때마다 꺼내서 사용하고 필요가 없으면 반환 (활성화 / 비활성화)
    // -> 메모리 할당과 해제를 최소화해서 성능 UP

    //필요 속성
    [Header("총알 프리팹")]
    [SerializeField] private Bullet _bulletPrefab;

    [Header("풀 사이즈")]
    [SerializeField] private int _poolSize;

    private Bullet[] _pool;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        //Pool을 풀 크기만큼 만듬
        _pool = new Bullet[_poolSize];

        //풀 크기 만큼 불렛을 미리 만들어서 넣음
        for (int i = 0; i < _poolSize; i++)
        {
            Bullet bullet = Instantiate(_bulletPrefab, gameObject.transform);
            bullet.gameObject.SetActive(false); // 일단 비활성화
            _pool[i] = bullet;
        }
    }

    public Bullet GetBullet()
    {
        foreach (Bullet bullet in _pool)
        {
            if (bullet.gameObject.activeSelf == false)
            {
                bullet.gameObject.SetActive(true);
                return bullet;
            }
        }

        return null;
    }
}