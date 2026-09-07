using UnityEngine;

public class ItemHpRecovery : Item
{
    [SerializeField] private int _hpRecoveryAmount = 40;

    protected override void ApplyEffect(GameObject player)
    {
        Player playerCs = player.GetComponent<Player>();
        playerCs.Heal(_hpRecoveryAmount);
    }
}