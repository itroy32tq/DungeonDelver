using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dalver 
{
    public class Tile : MonoBehaviour
    {
        [Header("Set Dynamically")]
        public int x;
        public int y;
        public int tileNum;

        [SerializeField]
        private BoxCollider bColl;


        public void SetTile(int eX, int eY, int eTileNum = -1)
        {
            x = eX; y = eY;
            transform.localPosition = new Vector3(x, y, 0f);
            gameObject.name = x.ToString("D3") + "x" + y.ToString("D3");
            if (eTileNum == -1)
            { 
                eTileNum = TileCamera.GET_MAP(x,y);
                
            }
            tileNum = eTileNum;
            if (tileNum > TileCamera.SPRITES.Length) return;
            GetComponent<SpriteRenderer>().sprite = TileCamera.SPRITES[tileNum];
            SetCollider();
        }

        private void SetCollider()
        {
            bColl.enabled = true;
            char c = TileCamera.COLLISIONS[tileNum];
            switch (c)
            { 
                case 'S':
                    bColl.center = Vector3.zero; 
                    break;
                default:
                    bColl.enabled = false; 
                    break;
            }
        }
    }
}

