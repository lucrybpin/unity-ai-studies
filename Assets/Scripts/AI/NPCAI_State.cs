using Opus.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Opus.AI {

    public class NPCAI_State : MonoBehaviour {

        State currentState;

        private void Awake ()
        {
            currentState = new StateIdle( GetComponent<CharacterMovement>() );
        }

        private void Update ()
        {
            currentState = currentState.Update();
        }

    }

}