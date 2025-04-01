using UnityEngine;

public class Grunt : EnemyBase
{
    public override void Initialize(Vector3 position)
    {
        base.Initialize(position);
        health = 50;
        speed = 3f;
        damage = 10f;
    }
    public override void Attak()
    {
        Debug.Log("Grunt가 근접 공격을 합니다.");
    }
}