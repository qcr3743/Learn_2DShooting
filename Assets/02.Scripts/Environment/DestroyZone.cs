using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    //충돌한 게임 오브젝트는 무조건 파괴
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}