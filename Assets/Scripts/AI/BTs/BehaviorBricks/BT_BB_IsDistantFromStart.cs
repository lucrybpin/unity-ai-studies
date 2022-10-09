using BBUnity.Conditions;
using Pada1.BBCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Condition("Character/IsDistantFromStart")]
public class BT_BB_IsDistantFromStart : GOCondition
{
    [InParam("origin")]
    public Vector3 start;


    public override bool Check()
    {
        float distance = Vector3.Distance(gameObject.transform.position, start);
        if (distance < 0.1f)
        {
            Debug.Log(distance);
            return false;
        }
        return true;
    }

}
