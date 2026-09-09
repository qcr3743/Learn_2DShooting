using TMPro;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    private int _killCount;
    [SerializeField] private TMP_Text _killCountText;

    private void Start()
    {
        UpdateKillCountUI();
    }

    public void RegisterEnemy(Enemy enemy) //구독
    {
        enemy.OnDeath += AddKillCount;
    }

    private void AddKillCount() //알림 -> 옵저버 행동
    {
        _killCount++;
        UpdateKillCountUI();
    }


    private void UpdateKillCountUI()
    {
        _killCountText.text = $"kILLCOUNT: {_killCount}";
    }
}