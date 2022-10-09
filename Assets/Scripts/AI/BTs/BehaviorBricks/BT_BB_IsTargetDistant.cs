using BBUnity.Conditions;
using Pada1.BBCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Condition("Character/IsTargetDistant")]
public class BT_BB_IsTargetDistant : GOCondition
{
    [InParam("target")]
    public GameObject target;

    [InParam("closeDistance")]
    public float closeDistance;


    public override bool Check()
    {
        return (gameObject.transform.position - target.transform.position).sqrMagnitude > closeDistance * closeDistance;
    }
}
