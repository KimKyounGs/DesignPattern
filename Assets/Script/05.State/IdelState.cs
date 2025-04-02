using UnityEngine;

public class IdelState : IState
{
    public void Enter()
    {
        Debug.Log("IdelState Enter");
    }

    public void Update()
    {
        Debug.Log("IdelState Update");
    }

    public void Exit()
    {
        Debug.Log("IdelState Exit");
    }
}
