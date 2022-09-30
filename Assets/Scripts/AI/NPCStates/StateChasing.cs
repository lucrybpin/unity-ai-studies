using Opus.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Opus.AI {

    public class StateChasing : State {

        CharacterMovement _player;
        float _distanceToPlayer;
        [SerializeField] float _inRangeDistance = 4f;

        public StateChasing (CharacterMovement owner)
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
        }

        public override State Update ()
        {
            Debug.Log( "Chasing" );

            _distanceToPlayer = Vector3.Distance( _owner.transform.position, _player.transform.position );

            if (_distanceToPlayer > _inRangeDistance)
                return new StateAlert( _owner );

            Vector3 moveDirection = _player.transform.position - _owner.transform.position;
            Vector2 inputDirection = new Vector2( moveDirection.x, moveDirection.z ).normalized;
            _owner.Input.MoveInput( inputDirection );

            if (_distanceToPlayer > 0f && _distanceToPlayer < 1f)
                return new StateAttack( _owner );

            return this;
        }
    }

}