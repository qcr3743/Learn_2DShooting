using UnityEngine;

public class ItemHpRecovery : Item
{
    [SerializeField] private int _hpRecoveryAmount = 40;

    protected override void ApplyEffect(GameObject player)
    {
        Player playerCs = player.GetComponent<Player>();
        Debug.Log($"플레이어 현재 체력: {playerCs.GetHp}");
        playerCs.Heal(_hpRecoveryAmount);
    }
}