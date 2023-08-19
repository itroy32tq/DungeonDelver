using Dalver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delver
{
    public class Dray : MonoBehaviour
    {
        [Header("Set in Inspector")]
        private float speed = 5;
        private float attackDuration = 0.25f;
        private float attackDelay = 0.5f;

        [Header("Set Dynamically")]
        public int dirHeld = -1;
        public int facing = 1;
        public EMode mode = EMode.idle;
        private float timeAtkDone = 0f;
        private float timeAtkNext = 0f;

        [SerializeField]
        private Rigidbody rigid;

        [SerializeField]
        private Animator animator;

        private Vector3[] directions = new Vector3[]
            {
                Vector3.right, Vector3.up, Vector3.left, Vector3.down
            };

        private KeyCode[] keys = new KeyCode[]
            {
                KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow
            };

        private void Update()
        {
            dirHeld = -1;

            for (int i = 0; i < 4; i++)
            { 
                if (Input.GetKey(keys[i])) dirHeld = i;
            }

            if (Input.GetKeyDown(KeyCode.Z) && Time.time >= timeAtkNext)
            {
                mode = EMode.attack;
                timeAtkDone = Time.time + attackDuration;
                timeAtkNext = Time.time + attackDelay;
            }

            if (Time.time >= timeAtkDone) mode = EMode.idle;

            if (mode != EMode.attack)
            {
                if (dirHeld == -1) mode = EMode.idle;
                else 
                {
                    facing = dirHeld;
                    mode = EMode.move;
                }
            }

            Vector3 vel = Vector3.zero;
            switch (mode)
            { 
                case EMode.attack:
                    animator.CrossFade("Dray_Attack_"+facing,0);
                    animator.speed = 0;
                    break;
                case EMode.idle:
                    animator.CrossFade("Dray_Walk_"+facing,0);
                    animator.speed = 0;
                    break;
                case EMode.move:
                    vel = directions[dirHeld];
                    animator.CrossFade("Dray_Walk_" + dirHeld, 0);
                    animator.speed = 1;
                    break;

            }
            rigid.velocity = vel*speed;
        }


    }
}
