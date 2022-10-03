
using Opus.Characters;
using System;
using UnityEngine;

namespace Opus.AI {

    [System.Serializable]
    public class State {

        [SerializeField] public CharacterMovement _owner;

        public virtual State Update () => new State();
    }

}