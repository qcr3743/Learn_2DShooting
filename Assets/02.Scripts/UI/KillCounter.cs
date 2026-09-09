using System.Collections;
using TMPro;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    private int _killCount;
    [SerializeField] private TMP_Text _killCountText;
    private Coroutine _textEffectCoroutine;

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

        if (_textEffectCoroutine != null)
        {
            StopCoroutine(_textEffectCoroutine);
        }

        _textEffectCoroutine = StartCoroutine(KillCountEffect());
    }


    private void UpdateKillCountUI()
    {
        _killCountText.text = $"KILLCOUNT: {_killCount}";
    }

    private IEnumerator KillCountEffect()
    {
        _killCountText.transform.localScale = Vector3.one * 1.3f;
        yield return new WaitForSeconds(0.15f);
        _killCountText.transform.localScale = Vector3.one;
    }
}