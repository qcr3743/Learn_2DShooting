using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnDataTableSO", menuName = "Scriptable Objects/EnemySpawnDataTableSO")]
//나중에 ScriptableObject 타입의 에셋 쉽게 만들라고 쓰는 용도, 없어도 가능
public class EnemySpawnDataTableSO : ScriptableObject
{
    public EnemySpawnData[] Datas;
}