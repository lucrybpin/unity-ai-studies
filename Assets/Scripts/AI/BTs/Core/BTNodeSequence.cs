using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Opus.AI {

    public class BTNodeSequence : BTNode {

        public BTNodeSequence () : base() { }
        public BTNodeSequence (List<BTNode> children) : base( children ) { }

        public override NodeState Evaluate ()
        {
            bool anyChildrenIsRunning = false;

            foreach (BTNode node in children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.Running:
                    anyChildrenIsRunning = true;
                    continue;

                    case NodeState.Success:
                    continue;

                    case NodeState.Failure:
                    this.state = NodeState.Failure;
                    continue;

                    default:
                    this.state = NodeState.Success;
                    return this.state;
                }
            }

            this.state = anyChildrenIsRunning ? NodeState.Running : NodeState.Success;
            return this.state;
        }

    }

}