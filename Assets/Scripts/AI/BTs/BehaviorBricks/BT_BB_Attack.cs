using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using UnityEngine;

[Action("Character/Attack")]
public class BT_BB_Attack : GOAction
{
    [InParam("TimeBetweenAttacks")]
    float timeBetweenAttacks;

    float elapsedTime;

    public override void OnStart()
    {
        base.OnStart();
        elapsedTime = 0f;
    }

    public override TaskStatus OnUpdate()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= timeBetweenAttacks)
        {
            Debug.Log("Attacking");
            elapsedTime = 0f;
        }

        return TaskStatus.RUNNING;
    }
}
