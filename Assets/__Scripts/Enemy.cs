using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dalver
{
    public abstract class Enemy : MonoBehaviour
    {
        protected static Vector3[] directions = new Vector3[]
            {
                Vector3.right, Vector3.up, Vector3.left, Vector3.down
            };

        [Header("Set in Inspector: Enemy")]
        public float maxHelth = 1;

        [Header("Set Dynamically: Enemy")]
        public float helth = 1;

        protected Animator animator;
        protected Rigidbody rigid;
        protected SpriteRenderer sRend;

        protected virtual void Awake()
        {
            helth = maxHelth;
            animator = GetComponent<Animator>();
            rigid = GetComponent<Rigidbody>();
            sRend = GetComponent<SpriteRenderer>();
        }


    }
}

