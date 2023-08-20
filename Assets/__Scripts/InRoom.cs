using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delver
{
    public class InRoom : MonoBehaviour
    {

        static public float ROOM_W = 16;
        static public float ROOM_H = 11;
        static public float WALL_T = 2;

        [Header("Set in Inspector")]
        public bool keepInRoom = true;
        public float gridMult;

        public Vector2 RoomPos
        {
            get
            {
                Vector2 tPos = transform.position;
                tPos.y %= ROOM_H;
                tPos.x %= ROOM_W;
                return tPos;
            }
            set 
            {
                Vector2 rm = RoomNum;
                rm.x *= ROOM_W;
                rm.y *= ROOM_H;
                rm += value;
                transform.position = rm;
            }
        }
        public Vector2 RoomNum
        {
            get 
            {
                Vector2 tPos = transform.position;
                tPos.x = Mathf.Floor(tPos.x / ROOM_W);
                tPos.y = Mathf.Floor(tPos.y / ROOM_H);
                return tPos;
            }
            set 
            {
                Vector2 rPos = RoomPos;
                Vector2 rm = value;
                rm.x *= ROOM_W;
                rm.y *= ROOM_H;
                transform.position = rm + rPos;
            }
        }

        public Vector2 GetRoomPosOnGrid(float mult = -1)
        {
            if (mult == -1) mult = gridMult;
            Vector2 rPos = RoomPos;
            rPos/=mult;
            rPos.x = Mathf.Round(rPos.x);
            rPos.y = Mathf.Round(rPos.y);
            rPos *= mult;
            return rPos;
        }

        private void LateUpdate()
        {
            if (keepInRoom)
            {
                Vector2 rPos = RoomPos;
                rPos.x = Mathf.Clamp(rPos.x, WALL_T, ROOM_W - 1 - WALL_T);
                rPos.y = Mathf.Clamp(rPos.y, WALL_T, ROOM_W - 1 - WALL_T);
                RoomPos = rPos;
            }
        }
    }
}

