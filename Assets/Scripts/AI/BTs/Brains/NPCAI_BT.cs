using Opus.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Opus.AI {

    public class NPCAI_BT : BTree {

        public CharacterMovement me;
        public CharacterMovement player;

        protected override BTNode SetupTree ()
        {
            //BTNode root = new TaskIdle();
            BTNode root = new BTNodeSelector( new List<BTNode>
            {
                new BTNodeSequence(new List<BTNode>
                {
                    new CheckPlayerInRange(this, 4f),
                    new TaskGoToTarget(this)
                } ),
                new TaskIdle(this)
            } );
            return root;
        }
    }

}