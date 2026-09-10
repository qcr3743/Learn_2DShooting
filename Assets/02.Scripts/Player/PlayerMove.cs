using UnityEngine;

//키보드 입력에 따른 플레이어 이동 처리
public class PlayerMove : MonoBehaviour
{
    //필요 필드:
    public float Speed;
    public float speedStep;
    float _orthographicSize;
    Vector3 _playerStartPos;
    private float _xBound;

    public float GetSpeed => Speed;

    private Animator _animator;

    //객체가 생성될(깨어날) 때 한 번 실행
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }


    void Start()
    {
        _orthographicSize = Camera.main.orthographicSize;
        _playerStartPos = transform.position;
        _xBound = _playerStartPos.x + _orthographicSize * (9f / 19f);
    }

    //매 프레임마다 실행
    // 초당 프레임 실행 횟수: 별다른 설정이 없을 경우 가능한 많이
    private void Update()
    {
        Move();
        SpeedChange();
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal"); // 키보드 왼/오른쪽 입력 상태에 따라 -1f ~ 0 ~ 1f
        float v = Input.GetAxis("Vertical"); //키보드 위/아래 입력 상태에 따라 -1f ~ 0 ~ 1f
        Vector2 direction = new Vector2(h, v);
        Vector2 normalizedDirection = direction.normalized;

        _animator.SetInteger("x", (int)normalizedDirection.x);

        SpeedChange();
        transform.Translate(normalizedDirection * Speed * Time.deltaTime);

        Vector3 playerPos = transform.position;

        if (playerPos.y > 5)
        {
            playerPos.y = 5;
        }
        else if (playerPos.y < -5)
        {
            playerPos.y = -5;
        }

        if (playerPos.x > _xBound)
        {
            playerPos.x = -_xBound;
        }
        else if (playerPos.x < -_xBound)
        {
            playerPos.x = _xBound;
        }

        transform.position = playerPos;
        //transform.Position도 가능은 한데 Vector3만 사용 가능, Vector2는 불가능
    }

    private void SpeedChange()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Speed += speedStep;
        }

        else if (Input.GetKeyDown(KeyCode.Q))
        {
            if ((Speed - speedStep) > 0)
            {
                Speed -= speedStep;
            }
        }
    }

    public void IncreaseSpeed(float _speedUpAmount)
    {
        Speed += _speedUpAmount;
        Debug.Log($"이동 속도 증가!: {Speed}");
    }
}