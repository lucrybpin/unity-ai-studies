using Opus.Characters;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Opus.AI {

    public class NPCAI : MonoBehaviour {

        [SerializeField] NPCStates currentState;

        [SerializeField] private StarterAssetsInputs _input;
        [SerializeField] CharacterMovement player;
        Vector2 inputDirection;
        [SerializeField] Transform idlePosition;

        float attackTimer = 0f;
        float attackTime = 1f;

        float goBackTimer = 0f;
        float goBackTime = 4f;

        

        public enum NPCStates {
            Idle,
            Chasing,
            Attacking,
            Alert,
            GoingBack
        }

        private void Start ()
        {
            currentState = NPCStates.Idle;
        }

        void Update ()
        {
            inputDirection = Vector2.zero;

            //Follow if in range
            float distanceToTarget = Vector3.Distance( player.transform.position, this.transform.position );
            if (distanceToTarget <= 4f)
            {
                goBackTimer = 0;

                Vector3 moveDirection = player.transform.position - this.transform.position;
                inputDirection = new Vector2( moveDirection.x, moveDirection.z ).normalized;

                if (distanceToTarget > 0f && distanceToTarget < 1f)
                {
                    //Attack
                    inputDirection = Vector2.zero;
                    attackTimer += Time.deltaTime;
                    if (attackTimer >= attackTime)
                    {
                        attackTimer = 0f;
                        Debug.Log( "Attack" );
                    }
                }
            }
            else
            {
                //Go Back to Idle
                goBackTimer += Time.deltaTime;
                if (goBackTimer >= goBackTime)
                {
                    Vector3 moveDirection = idlePosition.transform.position - this.transform.position;
                    inputDirection = new Vector2( moveDirection.x, moveDirection.z ).normalized;
                    distanceToTarget = Vector3.Distance( idlePosition.transform.position, this.transform.position );
                    if (distanceToTarget <= 0.1f)
                    {
                        goBackTimer = 0;
                    }
                }
            }

            _input.MoveInput( inputDirection );
        }
    }

}