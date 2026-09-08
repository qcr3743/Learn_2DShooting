using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    [SerializeField] private float _fireRate = 10f;
    private float _timer = 0f;
    public GameObject BombPrefab;

    private void Start()
    {
        _timer = _fireRate;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        FireBomb();
    }

    private void FireBomb()
    {
        if (Input.GetKeyDown(KeyCode.B) && (_timer >= _fireRate))
        {
            Instantiate(BombPrefab, transform.position + new Vector3(0, 4, 0), transform.rotation);
            _timer = 0f;
        }
    }
}