using UnityEngine;
//키보드 입력에 따른 플레이어 이동 처리
public class PlayerMove : MonoBehaviour
{
    //필요 필드:
    public float Speed;
    public float speedStep;
    float orthographicSize;
    Vector3 playerStartPos;
    private float xBound;

    void Start()
    {
        orthographicSize = Camera.main.orthographicSize;
        playerStartPos = transform.position;
        xBound = playerStartPos.x + orthographicSize * (9f / 19f);
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
        //1. 키보드 입력을 받음
        /*
        if(Input.GetKey(KeyCode.LeftArrow)) 
        {
            //2. 키보드 입력에 따라 방향을 구함
            //게임에는 벡터라는 타입이 있음(크기와 방향을 의미)
            Vector2 direction = new Vector2(-1, 0); //왼쪽 방향
            // = Vector2 direction Vector2.Left;
        
            //3. 방향과 속도에 따라 이동
            //속도 = 방향 * 속력
            //유니티 씬 중의 작은 격자 하나가 1unit = 대충 속도가 1이면 1unit만큼 움직임
            transform.Translate(direction * Speed * Time.deltaTime);
            //0.05f -> 매직 넘버: 보는 사람에 따라 의미가 달라질 수 있는 헷갈리는 숫자
            //코드에 가능한 매직 넘버는 없어야함
            //deltaTime: 이전 프레임으로부터 지금 프레임까지 시간이 얼마나 지났는지 MS로 반환 1초 나누기 프레임
        }
        */

        float h = Input.GetAxis("Horizontal"); // 키보드 왼/오른쪽 입력 상태에 따라 -1f ~ 0 ~ 1f
        float v = Input.GetAxis("Vertical"); //키보드 위/아래 입력 상태에 따라 -1f ~ 0 ~ 1f
        Vector2 direction = new Vector2(h, v);
        Vector2 normalizedDirection = direction.normalized;
        
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

        if (playerPos.x > xBound)
        {
            playerPos.x = -xBound;
        }
        else if (playerPos.x < -xBound)
        {
            playerPos.x = xBound;
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
            if ((Speed-speedStep) > 0)
            {
                Speed -= speedStep;
            }
        }
    }
}
