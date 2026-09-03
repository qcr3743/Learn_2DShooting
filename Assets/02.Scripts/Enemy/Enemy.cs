using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float health = 100;

    public abstract void Move();
}