using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawDataTableSO", menuName = "Scriptable Objects/EnemySpawDataTableSO")]
public class EnemySpawDataTableSO : ScriptableObject
{
    public EnemySpawnData[] Datas;
}