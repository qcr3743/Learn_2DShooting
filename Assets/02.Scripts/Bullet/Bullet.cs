using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    private void Start()
    {
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(new Vector2(0f, 1f) * speed * Time.deltaTime);
    }

    //충돌 관련 이벤트 (Enter -> Stay -> Exit)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("충돌 발생");

        //Bullet 파괴
        Destroy(this.gameObject);
        //충돌한 게임오브젝트파괴
        Destroy(collision.gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log("충돌 중");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Debug.Log("충돌 끝");
    }
}