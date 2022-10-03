using Opus.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Opus.AI {

    public class StateGoingBack : State {

        CharacterMovement _player;
        float _distanceToPlayer;
        float _inRangeDistance;
        Vector3 _initialPosition;

        public StateGoingBack (CharacterMovement owner)
        {
            _owner = owner;
            CharacterMovement [ ] characters = GameObject.FindObjectsOfType<CharacterMovement>();
            foreach (CharacterMovement character in characters)
            {
                if (character.IsPlayer)
                {
                    _player = character;
                    break;
                }
            }
            _inRangeDistance = 4f;
            _initialPosition = new Vector3( -3.75f, 0f, 0f );
        }

        public override State Update ()
        {
            Debug.Log( "Going Back" );

            Vector3 moveDirection = _initialPosition - _owner.transform.position;
            Vector2 inputDirection = new Vector2( moveDirection.x, moveDirection.z ).normalized;
            _owner.Input.MoveInput( inputDirection );

            if (Vector3.Distance(_owner.transform.position, _initialPosition) < 0.1f)
                return new StateIdle( _owner );

            return this;
        }

    } 

}
