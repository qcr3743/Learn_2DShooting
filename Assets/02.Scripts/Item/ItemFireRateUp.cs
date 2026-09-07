using UnityEngine;

public class ItemFireRateUp : Item
{
    [SerializeField] private float _fireRateUpAmount = 0.1f;

    protected override void ApplyEffect(GameObject player)
    {
        PlayerFire playerFire = player.GetComponent<PlayerFire>();
        playerFire.IncreaseFireRate(_fireRateUpAmount);
    }
}