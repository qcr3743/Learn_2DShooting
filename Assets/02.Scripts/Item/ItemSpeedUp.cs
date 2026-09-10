using UnityEngine;

public class ItemSpeedUp : Item
{
    [SerializeField] private float _speedUpAmount = 0.5f;

    protected override void ApplyEffect(GameObject player)
    {
        return;
        PlayerMove playerMove = player.GetComponent<PlayerMove>();
        Debug.Log($"플레이어 현재 이동속도: {playerMove.GetSpeed}");
        playerMove.IncreaseSpeed(_speedUpAmount);
    }
}