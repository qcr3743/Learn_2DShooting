using System.Collections;
using TMPro;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    private int _killCount;
    [SerializeField] private TMP_Text _killCountText;
    private Coroutine _textEffectCoroutine;
    [SerializeField] private float _effectDuration = 0.1f;

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
        float time = 0f;

        Vector3 normalScale = Vector3.one;
        Vector3 bigScale = Vector3.one * 1.3f;

        while (time < _effectDuration)
        {
            time += Time.deltaTime;
            float _timePercent = time / _effectDuration;
            _killCountText.transform.localScale = Vector3.Lerp(normalScale, bigScale, _timePercent);

            yield return null;
        }

        time = 0f;

        while (time < _effectDuration)
        {
            time += Time.deltaTime;
            float _timePercent = time / _effectDuration;
            _killCountText.transform.localScale = Vector3.Lerp(bigScale, normalScale, _timePercent);

            yield return null;
        }
    }
}