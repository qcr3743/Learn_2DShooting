using UnityEngine;

//역할: 일정 시간마다 적을 생성
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnInterval = 3f;
    private float _timer;

    [SerializeField] private Enemy[] _enemyprefabs;

    private void Start()
    {
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnInterval)
        {
            Spawn();
            _timer = 0;
            _spawnInterval = Random.Range(1f, 3f); //float: 1~3
            int randomInt = Random.Range(1, 3); //int: 1~2
        }
    }


    private void Spawn()
    {
        int randomIndex = Random.Range(1, 11);
        Debug.Log(randomIndex);
        if (randomIndex >= 1 && randomIndex <= 5)
        {
            Enemy enemy = Instantiate(_enemyprefabs[0]);
            enemy.transform.position = transform.position;
        }

        else if (randomIndex >= 6 && randomIndex <= 8)
        {
            Enemy enemy = Instantiate(_enemyprefabs[1]);
            enemy.transform.position = transform.position;
        }
        else
        {
            Enemy enemy = Instantiate(_enemyprefabs[2]);
            enemy.transform.position = transform.position;
        }
    }
}