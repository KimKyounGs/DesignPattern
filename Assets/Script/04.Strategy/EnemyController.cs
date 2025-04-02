using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Enemy _enemy;

    void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        // 키 입력에 따라 이동 전략 변경(테스트용)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _enemy.SetMovementStrategy(new StraightMovement());
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            _enemy.SetMovementStrategy(new CircleMovement());
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            _enemy.SetMovementStrategy(new ZigzagMovement());
        }
    }
}
