using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Opus.AI {
    public abstract class BTree : MonoBehaviour {

        BTNode _root = null;

        private void Start ()
        {
            _root = SetupTree();
        }

        private void Update ()
        {
            if (_root != null)
                _root.Evaluate();
        }

        protected abstract BTNode SetupTree ();

    }

}