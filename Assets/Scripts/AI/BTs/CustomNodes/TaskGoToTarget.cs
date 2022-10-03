using Opus.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Opus.AI {

    public class TaskGoToTarget : BTNode {

        private CharacterMovement me;
        private CharacterMovement player;

        public TaskGoToTarget (NPCAI_BT tree)
        {
            this.me = tree.me;
            this.player = tree.player;
        }

        public override NodeState Evaluate ()
        {
            float distance = Vector3.Distance( me.transform.position, player.transform.position );
            if (distance <= 1f)
            {
                Debug.Log( "Arrived" );
                state = NodeState.Success;
            } else
            {
                Debug.Log( "Going to target" );
                Vector3 moveDirection = player.transform.position - me.transform.position;
                Vector2 inputDirection = new Vector2( moveDirection.x, moveDirection.z ).normalized;
                me.Input.MoveInput( inputDirection );
                state = NodeState.Running;
            }
            return state;
        }


    }

}