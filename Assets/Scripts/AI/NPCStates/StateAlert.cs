using Opus.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Opus.AI {

    public class StateAlert : State {

        CharacterMovement _player;
        float _distanceToPlayer;
        float _inRangeDistance = 4f;
        float _elapsedTime;
        float _maxAlertTime = 7f;

        public StateAlert (CharacterMovement owner)
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
            _elapsedTime = 0;
        }

        public override State Update ()
        {
            Debug.Log( "Alert" );

            _distanceToPlayer = Vector3.Distance( _owner.transform.position, _player.transform.position );
            _elapsedTime += Time.deltaTime;

            _owner.Input.MoveInput( Vector2.zero );

            if (_distanceToPlayer <= _inRangeDistance)
                return new StateChasing( _owner );

            if (_elapsedTime >= _maxAlertTime)
                return new StateGoingBack(_owner);

            return this;
        }

    }

}