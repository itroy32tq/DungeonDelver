using Delver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

namespace Dalver
{
    public abstract class Enemy : Unit, IFacingMover
    {
        protected static Vector3[] directions = new Vector3[]
            {
                Vector3.right, Vector3.up, Vector3.left, Vector3.down
            };

        [Header("Set in Inspector: Enemy")]
        [SerializeField] protected float maxHelth = 1;

        [Header("Set Dynamically: Enemy")]
        [SerializeField] protected float helth = 1;

        protected SpriteRenderer sRend;
        new public bool Moving => true;


        protected override void Awake()
        {
            base.Awake();
            sRend = GetComponent<SpriteRenderer>();
        }

        public Vector2 GetRoomPosOnGrid(float mult = -1)
        {
            return InRm.GetRoomPosOnGrid();
        }
    }
}

