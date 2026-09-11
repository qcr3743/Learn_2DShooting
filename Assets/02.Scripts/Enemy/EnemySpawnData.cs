// 데이터 클래스: 순수하게 데이터(값)을 보관하고 전달하는 목적으로 만든 특별한 클래스

using UnityEngine;

[System.Serializable] //유니티가 일반 클래스 안의 데이터를 읽고 저장할 수 있게 해줌
public class EnemySpawnData
{
    public GameObject EnemyPrefab;
    public int Weight;
}