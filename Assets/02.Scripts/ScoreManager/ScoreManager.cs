using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance; //싱글톤 패턴
    public static ScoreManager Instance => _instance; //싱글톤 패턴

    private int _bestScore;
    private int _currentScore;
    [SerializeField] private TextMeshProUGUI _bestScoreTextUI;
    [SerializeField] private TextMeshProUGUI _currentScoreTextUI;
    private Coroutine _textEffectCoroutine;
    [SerializeField] private float _effectDuration = 0.1f;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this; //싱글톤 패턴, 나 자신이 생성되었다
    }


    private void Start()
    {
        UpdateKillCountUI();
    }


    private void Update()
    {
        if (_currentScore <= _bestScore) return;
        RefreshBestScore();
    }

    public void RefreshBestScore()
    {
        _bestScore = _currentScore;
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