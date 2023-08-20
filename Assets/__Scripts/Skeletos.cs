using Dalver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delver
{
    public class Skeletos : Enemy
    {
        [Header("Set in Inspector: Skeletos")]
        [SerializeField] private float timeThinkMin = 1f;
        [SerializeField] private float timeThinkMax = 4f;

        [Header("Set Dynamically: Skeletos")]
        [SerializeField] private float timeNextDecision = 0;

        private void Update()
        {
            if (Time.time >= timeNextDecision) DecideDirection();
            rigid.velocity = directions[facing] * speed;
        }

        private void DecideDirection()
        { 
            facing = Random.Range(0, 4);
            timeNextDecision = Time.time + Random.Range(timeThinkMin, timeThinkMax);
        }
    }
}
