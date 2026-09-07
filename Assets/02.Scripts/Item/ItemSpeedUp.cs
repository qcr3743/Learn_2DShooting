using UnityEngine;

public class ItemSpeedUp : Item
{
    [SerializeField] private float _speedUpAmount = 0.5f;

    protected override void ApplyEffect(GameObject player)
    {
        PlayerMove playerMove = player.GetComponent<PlayerMove>();
        playerMove.IncreaseSpeed(_speedUpAmount);
    }
}