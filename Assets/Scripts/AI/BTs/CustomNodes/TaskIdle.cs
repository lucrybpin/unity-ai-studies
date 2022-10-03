using Opus.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Opus.AI {

    public class TaskIdle : BTNode {

        private CharacterMovement me;

        public TaskIdle(NPCAI_BT tree)
        {
            this.me = tree.me;
        }

        public override NodeState Evaluate ()
        {
            Debug.Log("Running task Idle");
            me.Input.MoveInput( Vector2.zero );

            this.state = NodeState.Running;
            return this.state;
        }

    }

}