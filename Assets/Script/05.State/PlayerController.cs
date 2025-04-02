using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private StateMachine stateMachine;

    void Start()
    {
        stateMachine = new StateMachine();
        stateMachine.ChangeState(new IdelState()); // 처음에는 IdelState로 시작
    }

    void Update()
    {
        stateMachine.Update(); // 상태 머신의 Update 호출
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(new JumpState()); // Space 키를 누르면 JumpState로 전환
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            stateMachine.ChangeState(new RunState()); // 방향키를 누르면 RunState로 전환
        }
        else if (!Input.anyKey)
        {
            stateMachine.ChangeState(new IdelState()); // 아무 키도 누르지 않으면 IdelState로 전환
        }
    }
}
