using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("Character/Alert")]
public class BT_BB_Alert : GOAction
{
    [InParam("WaitTime")]
    float waitTime;

    float elapsedTime;

    public override void OnStart()
    {
        elapsedTime = 0f;
    }


    public override TaskStatus OnUpdate()
    {
        Debug.Log("Alert");

        elapsedTime += Time.deltaTime;

        if (elapsedTime >= waitTime)
            return TaskStatus.COMPLETED;

        return TaskStatus.RUNNING;
    }
}
