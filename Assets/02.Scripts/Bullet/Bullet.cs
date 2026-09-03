using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float damage = 40;

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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Bullet 파괴
            Destroy(this.gameObject);
            //GetComponent<타입>(): 게임오브젝트가 가지고 있는 컴포넌트를 참조
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            //<enemy>는 클래스 말하는거

            //응집도는 높히고, 결합도 낮춰라
            //결합도는 자주 묻는거
            //얘는 응집도가 낮아서 별로
            //enemy것들은 Enemy 클래스에 갖다두자
            /*
            enemy.health -= damage;
            Debug.Log($"{enemy.health}");
            if (enemy.health <= 0)
            {
                //충돌한 게임오브젝트파괴
                Destroy(collision.gameObject);
            }
            */
            enemy.TakeDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("충돌 발생");
        //Bullet 파괴
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Bullet 파괴
            Destroy(this.gameObject);
            //GetComponent<타입>(): 게임오브젝트가 가지고 있는 컴포넌트를 참조
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            //<enemy>는 클래스 말하는거

            //응집도는 높히고, 결합도 낮춰라
            //결합도는 자주 묻는거
            //얘는 응집도가 낮아서 별로
            //enemy것들은 Enemy 클래스에 갖다두자
            /*
            enemy.health -= damage;
            Debug.Log($"{enemy.health}");
            if (enemy.health <= 0)
            {
                //충돌한 게임오브젝트파괴
                Destroy(collision.gameObject);
            }
            */
            enemy.TakeDamage(damage);
        }
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