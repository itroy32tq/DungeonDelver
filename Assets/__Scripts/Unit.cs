using Dalver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delver
{
    public abstract class Unit : MonoBehaviour, IFacingMover
    {
        [Header("Set in Inspector Unit")]
        [SerializeField] protected float speed;

        [Header("Set Dynamically Unit")]
        [SerializeField] protected int facing = 1;
        [SerializeField] protected EMode mode = EMode.idle;

        public int Facing { get => facing; protected set => facing = value; }
        public EMode Mode { get => mode; protected set => mode = value; }
        protected Rigidbody rigid;
        protected Animator animator;
        protected InRoom InRm;

        public bool Moving => mode == EMode.move;
        public float GridMult => InRm.gridMult;
        public Vector2 RoomPos { get => InRm.RoomPos; set => InRm.RoomPos = value; }
        public Vector2 RoomNum { get => InRm.RoomNum; set => InRm.RoomNum = value; }
        public int GetFacing()
        {
            return facing;
        }
        public float GetSpeed()
        {
            return speed;
        }
        public Vector2 GetRoomPosOnGrid(float mult = -1)
        {
            return InRm.GetRoomPosOnGrid();
        }
        protected virtual void  Awake() 
        {
            rigid = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
            InRm = GetComponent<InRoom>();
        }
    }
}

