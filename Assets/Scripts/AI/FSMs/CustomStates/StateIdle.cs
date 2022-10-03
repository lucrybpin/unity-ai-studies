using Opus.Characters;
using UnityEngine;

namespace Opus.AI {
    public class StateIdle : State {

        CharacterMovement _player;
        float _distanceToPlayer;
        float _closeDistance = 4f;

        public StateIdle (CharacterMovement owner)
        {
            _owner = owner;
            CharacterMovement [] characters = GameObject.FindObjectsOfType<CharacterMovement>();
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
            Debug.Log( "Idle" );

            _distanceToPlayer = Vector3.Distance( _owner.transform.position, _player.transform.position );

            _owner.Input.MoveInput( Vector2.zero );

            if (_distanceToPlayer <= _closeDistance)
                return new StateChasing( _owner );

            return this;
        }
    }

}