using UnityEngine;

//역할: 일정 시간마다 적을 생성
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnInterval = 3f;

    [SerializeField] private EnemySpawnDataTableSO _spawnDataTable;


    private float _timer;

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
        // 가중치 랜덤 선택
        // 각 아이템에 가중치를 부여하고, 가중치가 클수록 선택되도록
        // 아이템이 수십개가 넘으면 일일히 합쳐서 100%되게 힘드니까, 가중치로 (가중치 / 가중치 전체합) * 100으로 하면됨

        // 1. 추첨할 수 있는 모든 가중치를 더함
        int totalWeight = 0;
        foreach (EnemySpawnData data in _spawnDataTable.Datas)
        {
            totalWeight += data.Weight;
        }

        // 2. 전체 가중치 범위에서 랜덤한 정수를 뽑음
        int randomWeight = Random.Range(0, totalWeight);

        // 3. 가중치를 누적하면서 선택된 구간을 찾음
        int cumulativeWeight = 0;

        foreach (EnemySpawnData data in _spawnDataTable.Datas)
        {
            cumulativeWeight += data.Weight;
            if (randomWeight < cumulativeWeight)
            {
                GameObject enemy = Instantiate(data.EnemyPrefab);
                enemy.transform.position = transform.position;
                break;
            }
        }
    }
}