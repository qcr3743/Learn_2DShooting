using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _hp = 100;

    private void Start()
    {
    }

    private void Update()
    {
    }

    public void TakeDamage(int damage)
    {
        _hp -= damage;
        Debug.Log($"피격받았다! 플레이어의 HP: {_hp}");
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Heal(int _hpRecoveryAmount)
    {
        _hp += _hpRecoveryAmount;
        Debug.Log($"회복! 플레이어의 HP: {_hp}");
    }
}