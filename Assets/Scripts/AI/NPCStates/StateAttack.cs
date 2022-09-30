using Opus.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Opus.AI {
    public class StateAttack : State {

        CharacterMovement _player;
        float _distanceToPlayer;
        float _attackElapsedTime;
        float _timeBetweenAttacks;
        float _inRangeDistance;

        public StateAttack (CharacterMovement owner)
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
            _timeBetweenAttacks = 1f;
            _inRangeDistance = 1f;
        }

        public override State Update ()
        {
            Debug.Log( "Attacking" );

            _distanceToPlayer = Vector3.Distance( _owner.transform.position, _player.transform.position );
            Vector2 inputDirection = Vector2.zero;
            _owner.Input.MoveInput( inputDirection );

            _attackElapsedTime += Time.deltaTime;

            if (_attackElapsedTime >= _timeBetweenAttacks)
            {
                _attackElapsedTime = 0f;
                Debug.Log( "Attack" );
            }

            if (_distanceToPlayer > _inRangeDistance)
                return new StateChasing( _owner );

            return this;
        }
    }
}
