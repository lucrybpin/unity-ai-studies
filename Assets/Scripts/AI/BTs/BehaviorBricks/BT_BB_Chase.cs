using UnityEngine;
using Pada1.BBCore;
using BBUnity.Actions;
using Pada1.BBCore.Tasks;

using Opus.Characters;

[Action("Character/Chase")]
public class BT_BB_Chase : GOAction
{
    [InParam("Target")]
    GameObject target;

    CharacterMovement characterMovement;

    public override void OnStart()
    {
        base.OnStart();
        characterMovement = gameObject.GetComponent<CharacterMovement>();
    }

    public override TaskStatus OnUpdate()
    {

        Vector3 direction = target.transform.position - gameObject.transform.position;
        Vector2 inputDirection = new Vector2(direction.x, direction.z).normalized;
        characterMovement.Input.MoveInput(inputDirection);

        return TaskStatus.RUNNING;
    }

    public override void OnAbort()
    {
        base.OnAbort();
        characterMovement.Input.MoveInput(Vector2.zero);
    }
}