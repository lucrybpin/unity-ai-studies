using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Opus.AI {

    public class BTNodeSelector : BTNode {

        public BTNodeSelector () : base() { }
        public BTNodeSelector (List<BTNode> children) : base( children ) { }

        public override NodeState Evaluate ()
        {
            foreach (BTNode node in children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.Running:
                    this.state = NodeState.Running;
                    return this.state;

                    case NodeState.Success:
                    this.state = NodeState.Success;
                    return this.state;

                    case NodeState.Failure:
                    continue;

                    default:
                    continue;
                }
            }

            this.state = NodeState.Failure;
            return this.state;
        }

    }

}