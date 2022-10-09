using Pada1.BBCore.Framework;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using UnityEngine;

[Action("Character/Idle")]
public class BT_BB_Idle : BasePrimitiveAction
{

    public override void OnStart()
    {
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        Debug.Log("Running");
        return TaskStatus.RUNNING;
    }
}
