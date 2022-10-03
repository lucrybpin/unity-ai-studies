using Opus.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Opus.AI {
    public class CheckPlayerInRange : BTNode {

        private CharacterMovement me;
        private CharacterMovement player;
        private float range;

        public CheckPlayerInRange (NPCAI_BT tree, float range)
        {
            this.me = tree.me;
            this.player = tree.player;
            this.range = range;
        }

        public override NodeState Evaluate ()
        {
            

            float distance = Vector3.Distance( me.transform.position, player.transform.position );
            if (distance <= range)
            {
                Debug.Log( "Player in range" );
                state = NodeState.Success;
            } else
            {
                Debug.Log( "Player not in range" );
                state = NodeState.Failure;
            }
            return state;
        }
    }

}