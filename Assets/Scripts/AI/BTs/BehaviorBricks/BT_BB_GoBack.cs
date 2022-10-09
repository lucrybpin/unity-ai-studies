using BBUnity.Actions;
using Opus.Characters;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("Character/GoBack")]
public class BT_BB_GoBack : GOAction
{
    [InParam("InitialPosition")]
    Vector3 initialPosition;

    CharacterMovement characterMovement;


    public override void OnStart()
    {
        base.OnStart();
        characterMovement = gameObject.GetComponent<CharacterMovement>();
    }

    public override TaskStatus OnUpdate()
    {
        Debug.Log("Going back");

        Vector3 direction = initialPosition - gameObject.transform.position;
        Vector2 inputDirection = new Vector2(direction.x, direction.z).normalized;
        characterMovement.Input.MoveInput(inputDirection);

        float distance = Vector3.Distance(initialPosition, gameObject.transform.position);
        if (distance <= 0.1f)
        {
            return TaskStatus.COMPLETED;
        }

        return TaskStatus.RUNNING;
    }

    public override void OnAbort()
    {
        base.OnAbort();
        characterMovement.Input.MoveInput(Vector2.zero);
    }
}
