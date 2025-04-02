using UnityEngine;

public interface IState
{
    void Enter();   // 상태 진입 시 실행
    void Update();  // 상태 유지 시 실행
    void Exit();    // 상태 종료 시 실행
}
