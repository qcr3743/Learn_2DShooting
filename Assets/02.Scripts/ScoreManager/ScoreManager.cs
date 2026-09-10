using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //관리: 특정 데이터에 대한 무결성과 추가 수정 삭제 등과 관련되 로직

    private int _bestScore;
    private int _currentScore;
    [SerializeField] private TextMeshProUGUI _bestScoreTextUI;
    [SerializeField] private TextMeshProUGUI _currentScoreTextUI;
    private Coroutine _textEffectCoroutine;
    [SerializeField] private float _effectDuration = 0.1f;

    private void Start()
    {
        UpdateKillCountUI();
    }


    private void Update()
    {
        if (_currentScore > _bestScore)
        {
            RefreshBestScore();
        }
    }

    public void RefreshBestScore()
    {
        _bestScoreTextUI.text = $"BestScore: {_bestScore}";
    }


    public void RegisterEnemy(Enemy enemy) //구독
    {
        enemy.OnDeath += AddKillCount;
    }

    private void AddKillCount() //알림 -> 옵저버 행동
    {
        _currentScore++;
        UpdateKillCountUI();

        if (_textEffectCoroutine != null)
        {
            StopCoroutine(_textEffectCoroutine);
        }

        _textEffectCoroutine = StartCoroutine(KillCountEffect());
    }


    private void UpdateKillCountUI()
    {
        _currentScoreTextUI.text = $"Score: {_currentScore}";
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
            _currentScoreTextUI.transform.localScale = Vector3.Lerp(normalScale, bigScale, _timePercent);

            yield return null;
        }

        time = 0f;

        while (time < _effectDuration)
        {
            time += Time.deltaTime;
            float _timePercent = time / _effectDuration;
            _currentScoreTextUI.transform.localScale = Vector3.Lerp(bigScale, normalScale, _timePercent);

            yield return null;
        }
    }
}