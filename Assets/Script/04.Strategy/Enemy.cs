using UnityEngine;

//스트래티지 패턴은 알고리즘을 캡슐화하고 필요에 따라 교체할 수 있게 하는 패턴입니다.
//Unity에서는 AI 행동, 캐릭터 움직임 등에 유용합니다.

public interface IMovementStrategy
{
    void Move(Transform transform, float speed);
}

public class StraightMovement : IMovementStrategy
{
    public void Move(Transform transform, float speed)
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}

public class ZigzagMovement : IMovementStrategy
{
    private float _amplitude = 0.5f;
    private float _frequency = 1f;
    private float _time = 0;


    public void Move(Transform transform, float speed)
    {
        _time += Time.deltaTime;
        
        // 직선이동
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
        //좌우 움직임 추가
        float xOffset = Mathf.Sin(_time * _frequency) * _amplitude; 
        transform.position = new Vector3(xOffset, transform.position.y, transform.position.z);
    }
}

public class CircleMovement : IMovementStrategy
{
    private float _radius = 5f;
    private float _angularSpeed = 50f; 
    private float _angle = 0;
    private Vector3 _center;
    private bool _isInitialized = false;

    public void Move(Transform transform, float speed)
    {
        // 원의 중심을 초기화
        if (!_isInitialized)
        {
            _center = transform.position;
            _isInitialized = true;
        }

        // 원을 그리며 이동
        _angle += _angularSpeed * Time.deltaTime;

        float x = _center.x + _radius * Mathf.Cos(_angle);
        float z = _center.z + _radius * Mathf.Sin(_angle);

        transform.position = new Vector3(x, transform.position.y, z);

        // 회전 방향 고려
        transform.LookAt(new Vector3(_center.x + Mathf.Cos(_angle) * _radius, 
                                    transform.position.y, 
                                    _center.z + Mathf.Sin(_angle) * _radius));
        
    }
}

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    // 현재 이동 전략
    private IMovementStrategy _movementStrategy;

    private void Start()
    {
        _movementStrategy = new StraightMovement(); // 기본 이동 전략
    }

    // 이동 전략 변경 메서드
    public void SetMovementStrategy(IMovementStrategy strategy) 
    {
        _movementStrategy = strategy; 
    }

    private void Update()
    {
        if (_movementStrategy == null)
            return;
        // 현재 이동 전략에 따라 이동
        _movementStrategy.Move(transform, _speed);
    }
}
