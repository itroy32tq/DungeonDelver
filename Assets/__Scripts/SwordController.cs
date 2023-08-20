using Dalver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delver
{
    public class SwordController : MonoBehaviour
    {
        [SerializeField]
        private GameObject sword;

        [SerializeField]
        private Dray dray;

        private void Start()
        {
            sword.SetActive(false);
        }

        private void Update() 
        { 
            transform.rotation = Quaternion.Euler(0,0,90*dray.Facing);
            sword.SetActive(dray.Mode == EMode.attack);
        }
    }
}
